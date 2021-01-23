    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    
    namespace WorkerRoleWithSBQueue1
    {
    	public class WorkerRole : RoleEntryPoint
    	{
    		// The name of your queue
    		const string QueueName = "QUEUE_NAME";
    		const int MaxThreads = 3;
    
    		// QueueClient is thread-safe. Recommended that you cache 
    		// rather than recreating it on every request
    		QueueClient Client;
    		bool IsStopped;
    		int dequeueRequests = 0;
    
    		public override void Run()
    		{
    			while (!IsStopped)
    			{
    				// Increment Request Counter
    				Interlocked.Increment(ref dequeueRequests);
    
    				Trace.WriteLine(dequeueRequests + " request(s) in progress");
    
    				Client.BeginReceive(new TimeSpan(0, 0, 10), ProcessUrgentEmails, Client);
    
    				// If we have made too many requests, wait for them to finish before requesting again.
    				while (dequeueRequests >= MaxThreads && !IsStopped)
    				{
    					System.Diagnostics.Trace.WriteLine(dequeueRequests + " requests in progress, waiting before requesting more work");
    					Thread.Sleep(2000);
    				}
    
    			}
    		}
    
    
    		void ProcessUrgentEmails(IAsyncResult result)
    		{
    			var qc = result.AsyncState as QueueClient;
    			var sendEmail = qc.EndReceive(result);
    			// We have received a message or has timeout... either way we decrease our counter
    			Interlocked.Decrement(ref dequeueRequests);
    
    			// If we have a message, process it
    			if (sendEmail != null)
    			{
    				var r = new Random();
    				// Process the message
    				Trace.WriteLine("Processing message: " + sendEmail.MessageId);
    				System.Threading.Thread.Sleep(r.Next(10000));
    
    				// Mark it as completed
    				sendEmail.BeginComplete(ProcessEndComplete, sendEmail);
    			}
    
    		}
    
    
    		void ProcessEndComplete(IAsyncResult result)
    		{
    			var bm = result.AsyncState as BrokeredMessage;
    			bm.EndComplete(result);
    			Trace.WriteLine("Completed message: " + bm.MessageId);
    		}
    
    
    		public override bool OnStart()
    		{
    			// Set the maximum number of concurrent connections 
    			ServicePointManager.DefaultConnectionLimit = 12;
    
    			// Create the queue if it does not exist already
    			string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
    			var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
    			if (!namespaceManager.QueueExists(QueueName))
    			{
    				namespaceManager.CreateQueue(QueueName);
    			}
    
    			// Initialize the connection to Service Bus Queue
    			Client = QueueClient.CreateFromConnectionString(connectionString, QueueName);
    			IsStopped = false;
    			return base.OnStart();
    		}
    
    		public override void OnStop()
    		{
    			// Waiting for all requestes to finish (or timeout) before closing
    			while (dequeueRequests > 0)
    			{
    				System.Diagnostics.Trace.WriteLine(dequeueRequests + " request(s), waiting before stopping");
    				Thread.Sleep(2000);
    			}
    			// Close the connection to Service Bus Queue
    			IsStopped = true;
    			Client.Close();
    			base.OnStop();
    		}
    	}
    }
