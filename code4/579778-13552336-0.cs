            static void Main(string[] args)
        {
            TcpClient client = new TcpClient("216.18.20.172", 2628);
            try
            {
                Stream s = client.GetStream();
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                Console.WriteLine(sr.ReadLine());
                while (true)
                {
                    Console.Write("Word: ");
                    string msg = Console.ReadLine();
                    sw.WriteLine("D wn {0}", msg);
                    if (msg == "") break;
                    var line = sr.ReadLine();
                    while (line != ".") // The dot character is used as an indication that no more words are found
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.ReadLine();
                }
                s.Close();
            }
            finally
            {
                client.Close();
                Console.ReadLine();
            }
        }
