        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the computer you wish to disable");
            string ComputerName = Console.ReadLine();
            if (ComputerName != "" && ComputerName != null)
            {
                using (PrincipalContext TargetDomain = new PrincipalContext(ContextType.Domain, null, "admin", "password"))
                {
                    ComputerPrincipal TargetComputer = ComputerPrincipal.FindByIdentity(TargetDomain, ComputerName);
                    if (TargetComputer != null)
                    {
                        if ((bool)TargetComputer.Enabled)
                        {
                            Console.WriteLine("Computer is currently enabled, it will now be disabled");
                            TargetComputer.Enabled = false;
                            Console.WriteLine("Is computer now enabled? " + TargetComputer.Enabled);
                            TargetComputer.Save();
                        }
                        else
                        {
                            Console.WriteLine("Computer is currently disabled, it will now be enabled");
                            TargetComputer.Enabled = true;
                            Console.WriteLine("Is computer now enabled? " + TargetComputer.Enabled);
                            TargetComputer.Save();
                        }
                        Console.Read();
                    }
                }
            }
        }
