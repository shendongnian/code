    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    
    namespace WorkerRoleWithSBQueue1
    {
        public class WorkerRole : RoleEntryPoint
        {
            // The name of your queue
            const string QueueName = "demoapp";
            ManualResetEvent CompletedEvent = new ManualResetEvent(false);
        // QueueClient is thread-safe. Recommended that you cache 
        // rather than recreating it on every request
        QueueClient Client;
        public override void Run()
        {
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = true; // Indicates if the message-pump should call complete on messages after the callback has completed processing.
            options.MaxConcurrentCalls = 1; // Indicates the maximum number of concurrent calls to the callback the pump should initiate 
            options.ExceptionReceived += LogErrors; // Allows users to get notified of any errors encountered by the message pump
            Trace.WriteLine("Starting processing of messages");
            // Start receiveing messages
            Client.OnMessage((receivedMessage) => // Initiates the message pump and callback is invoked for each message that is recieved, calling close on the client will stop the pump.
                {
                    try
                    {
                        // Process the message
                        Trace.WriteLine("Processing Service Bus message: " + receivedMessage.SequenceNumber.ToString());
                    }
                    catch
                    {
                        // Handle any message processing specific exceptions here
                    }
                }, options);
            CompletedEvent.WaitOne();
        }
        private void LogErrors(object sender, ExceptionReceivedEventArgs e)
        {
            if (e.Exception != null)
            {
                Trace.WriteLine("Error: " + e.Exception.Message);
            }
        }
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;
            // Create the queue if it does not exist already
            Trace.WriteLine("Creating Queue");
            string connectionString = "*** provide your connection string here***";
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            if (!namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.CreateQueue(QueueName);
            }
            // Initialize the connection to Service Bus Queue
            Client = QueueClient.CreateFromConnectionString(connectionString, QueueName);
            
            Trace.WriteLine("Sending messages...");
            // populate some messages
            for (int ctr = 0; ctr < 10; ctr++)
            {
                Client.Send(new BrokeredMessage());
            }
            
            return base.OnStart();
        }
        public override void OnStop()
        {
            // Close the connection to Service Bus Queue
            Client.Close();
            CompletedEvent.Set(); // complete the Run function
            base.OnStop();
        }
    }
}
