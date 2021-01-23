    namespace Students
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create the address for the service
                Uri address = new Uri("http://localhost:8001");
                // Create the binding for the service
                WSHttpBinding binding = new WSHttpBinding();
                // Create the service object
                StudentService service = new StudentService();
                // Create the host for the service
                ServiceHost host = new ServiceHost(service, address);
                // Add the endpoint for the service using the contract, binding and name
                host.AddServiceEndpoint(typeof(IStudentService),
                                        binding,
                                        "students");
    
                // Add metadata exchange
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);
                // Open the host
                host.Open();
                Console.WriteLine("Student service started");
                Console.WriteLine("Press return to exit");
                Console.ReadLine();
                // Close the host
                host.Close();
            }
        }
    }
