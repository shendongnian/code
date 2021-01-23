     TcpClient client = new TcpClient("localhost", 9999);
            Stream s = client.GetStream();
            Console.WriteLine("Connection successfully received");
            StreamWriter writer = new StreamWriter(s);
            StreamReader reader = new StreamReader(s);
            sw.AutoFlush = true;
            string dis=reader.readLine();
            Console.WriteLine(dis); 
