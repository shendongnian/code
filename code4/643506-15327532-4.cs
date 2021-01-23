    static void MakeRequest()
            {
                try
                {
                    using (var svc = new Service1Client())
                    {
                        Console.WriteLine(svc.GetData());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
    
            static void Test3()
            {            
                Console.WriteLine("using {0}", ToString(WindowsIdentity.GetCurrent()));
                MakeRequest();
                Console.WriteLine();
    
                Console.WriteLine("setting svc.ClientCredentials.Windows.ClientCredential to null...");
                try
                {
                    using (var svc = new Service1Client())
                    {
                        svc.ClientCredentials.Windows.ClientCredential = null; 
                        Console.WriteLine(svc.GetData());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                Console.WriteLine();
    
                ImpersonateAnonymousUser();
                Console.WriteLine("using {0}", ToString(WindowsIdentity.GetCurrent()));
                MakeRequest();
                Console.WriteLine();
            }
