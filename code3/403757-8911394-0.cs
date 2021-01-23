    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CalculatorService : ICalculatorInstance
    {
        static Object syncObject = new object();
        static int instanceCount;
        int instanceId;
        int operationCount;
    
        public CalculatorService()
        {
            lock (syncObject)
            {
                instanceCount++;
                instanceId = instanceCount;
            }
        }
    
        public double Add(double n1, double n2)
        {
            operationCount++;
            return n1 + n2;
        }
    
        public double Subtract(double n1, double n2)
        {
            Interlocked.Increment(ref operationCount);
            return n1 - n2;
        }
    
        public double Multiply(double n1, double n2)
        {
            Interlocked.Increment(ref operationCount);
            return n1 * n2;
        }
    
        public double Divide(double n1, double n2)
        {
            Interlocked.Increment(ref operationCount);
            return n1 / n2;
        }
    
        public string GetInstanceContextMode()
        {   // Return the InstanceContextMode of the service
            ServiceHost host = (ServiceHost)OperationContext.Current.Host;
            ServiceBehaviorAttribute behavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            return behavior.InstanceContextMode.ToString();
        }
    
        public int GetInstanceId()
        {   // Return the id for this instance
            return instanceId;
        }
    
        public int GetOperationCount()
        {   // Return the number of ICalculator operations performed 
            // on this instance
            lock (syncObject)
            {
                return operationCount;
            }
        }
    }
    
    public class Program
    {
    
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:12345/calc");
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
    
                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();
    
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
    
                // Close the ServiceHost.
                host.Close();
            }
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
