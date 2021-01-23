    using System;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Principal;
    
    namespace WindowsIdentityTest
    {
        class Program
        {
            [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
            static string SomeServerAction()
            { return "Authenticated users can access"; }
    
            [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Administrateurs")]
            static string SomeCriticalServerAction()
            { return "Only Admins can access"; }
    
            static void Main(string[] args)
            {
                //This allows to perform security checks against the current Identity.   
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                
                try
                {
                    Console.WriteLine(SomeServerAction());
                    Console.WriteLine(SomeCriticalServerAction());
    
                }
                catch (SecurityException sec)
                {
                    Console.WriteLine(string.Format("{0} : {1}\n------------\n{2}"
                        , sec.GetType()
                        , sec.Message
                        , sec.StackTrace));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("This shall not appen.");
                }
                Console.WriteLine("Press enter to quit.");
                Console.ReadLine();
            }
        }
    }
