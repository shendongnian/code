    static void FindAnyTimeServer(DirectoryContext context)
        {
            try
            {
                DomainController dc = DomainController.GetDomainController(context);
                DateTime dt = dc.CurrentTime;
                Console.WriteLine("A time server for {0} is {1}.", context.Name, dt);           
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                Console.WriteLine("No time server was found in {0}.", context.Name);
            }
           
        }
