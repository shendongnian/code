     static void FindAnyTimeServer(DirectoryContext context)
        {
            try
            {
                DomainController dc = DomainController.GetDomainController(context);
                Console.WriteLine("A time server for {0} is {1}.", context.Name, dc.Name);
                DateTime dt = dc.CurrentTime;
                Console.WriteLine("Current Time is {0}", dt);
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                Console.WriteLine("No time server was found in {0}.", context.Name);
            }
           
        }
