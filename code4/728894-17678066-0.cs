    #region MyRegion
    using System;
    using System.Runtime.Serialization;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging; 
    #endregion
    
    namespace StackOverflow
    {
        static class Program
        {
            #region Private Constants
            private const string QueueName = "stackoverflow";
            private const string MessageType = "MessageType";
            private const string AssemblyName = "AssemblyName";
            private const string ConnectionString = "<your-service-bus-namespace-connectionstring>"; 
            #endregion
    
            #region Static Methods
            static void Main()
            {
                SendMessage();
            }
    
            static async void SendMessage()
            {
                try
                {
                    // Create NamespaceManager object
                    var namespaceManager = NamespaceManager.CreateFromConnectionString(ConnectionString);
                    Console.WriteLine("NamespaceManager successfully created.");
    
                    // Create test queue
                    if (!namespaceManager.QueueExists(QueueName))
                    {
                        namespaceManager.CreateQueue(new QueueDescription(QueueName)
                        {
                            RequiresDuplicateDetection = false,
                            RequiresSession = false,
                            LockDuration = TimeSpan.FromSeconds(60)
                        });
                        Console.WriteLine("Queue successfully created.");
                    }
    
                    // Create MessagingFactory object
                    var messagingFactory = MessagingFactory.CreateFromConnectionString(ConnectionString);
                    Console.WriteLine("MessagingFactory successfully created.");
    
                    // Create MessageSender object
                    var messageSender = await messagingFactory.CreateMessageSenderAsync(QueueName);
                    Console.WriteLine("MessageSender successfully created.");
    
                    // Create message payload
                    var testServiceBusMessage = new TestServiceBusMessage
                    {
                        ExternalIdentifier = Guid.NewGuid(),
                        Identifier = 1,
                        Name = "Babo"
                    };
    
                    // Create BrokeredMessage object
                    using (var brokeredMessage = new BrokeredMessage(testServiceBusMessage,
                                                                     new DataContractSerializer(typeof(TestServiceBusMessage)))
                    {
                        Properties = {{MessageType, typeof(TestServiceBusMessage).FullName},
                                      {AssemblyName, typeof(TestServiceBusMessage).AssemblyQualifiedName}}
                    })
                    {
                        //Send message
                        messageSender.SendAsync(brokeredMessage).Wait();
                    }
                    Console.WriteLine("Message successfully sent.");
                    Console.WriteLine("Press [Enter] to exit");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press [Enter] to exit");
                    Console.ReadLine();
                }
            } 
            #endregion
        }
    
        [DataContract]
        public class TestServiceBusMessage
        {
            [DataMember]
            public Guid ExternalIdentifier { get; set; }
    
            [DataMember]
            public int Identifier { get; set; }
    
            [DataMember]
            public string Name { get; set; }
        }
    }
