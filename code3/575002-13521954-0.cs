    static void Main(string[] args)
            {
                Console.Write("User name:");
                string user = Console.ReadLine();
                Console.Write("Password:");
                string password = Console.ReadLine();
                Console.Write("File name:");
                string fileName = Console.ReadLine();
    
                System.Security.SecureString ss = new System.Security.SecureString();
                foreach (var c in password)
                {
                    ss.AppendChar(c);
                }
    
                Process process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = "c:\\";
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "runas";
                process.StartInfo.UserName = user;
                process.StartInfo.Password = ss;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                
                Console.ReadKey();
            }
