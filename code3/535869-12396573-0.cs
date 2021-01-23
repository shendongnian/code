    class Program
        {
            static void Main(string[] args)
            {
                string serverName = "localhost";
                using (Microsoft.Web.Administration.ServerManager sm = Microsoft.Web.Administration.ServerManager.OpenRemote(serverName))
                {
                    int counter = 1;
                    foreach (var site in sm.Sites)
                    {
                        Console.Write(String.Format(CultureInfo.InvariantCulture, "Site number {0} : {1}{2}", counter.ToString(), site.Name, Environment.NewLine));
                        counter++;
                    }
                }
                Console.ReadLine();
            }
        }
