    static Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
           {
                //replace the if check with more reliable check such as matching the public key as well
                if (args.Name.Contains(Assembly.GetExecutingAssembly().GetName().Name))
                {
                    Console.WriteLine("Resolved " + args.Name + " as " + Assembly.GetExecutingAssembly().GetName());
                    return Assembly.GetExecutingAssembly();
                }
                return null;
           }
