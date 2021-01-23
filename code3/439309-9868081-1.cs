    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Net.Sockets;
    class Program
    {
        private static Regex _regex = new Regex("and|so|not|c|to|by|has|do|behavior|dance|france|ok|thast|please|hello|system|possible|impossible|absolutely|sachin|bradman|schumacher|http|console|application", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    
        static void Main(string[] args)
        {
            TcpListener serversocket = new TcpListener(8888);
            TcpClient clientsocket = default(TcpClient);
            serversocket.Start();
            Console.WriteLine(">> Server Started");
            clientsocket = serversocket.AcceptTcpClient();
            Console.WriteLine("Accept Connection From Client");
    
            try
            {
                using (var reader = new StreamReader(clientsocket.GetStream()))
                {
                    string line;
                    int lineNumber = 0;
                    while (null != (line = reader.ReadLine()))
                    {
                        lineNumber += 1;
                        foreach (Match match in _regex.Matches(line))
                        {
                            Console.WriteLine("Line {0} matches {1}", lineNumber, match.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        
            clientsocket.Close();
            serversocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }
    } 
