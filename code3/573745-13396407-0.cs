            Socket soc = listener.AcceptSocket();
            Console.WriteLine("Connection successful");
            Stream s = new NetworkStream(soc);
            StreamReader reader = new StreamReader(s);
            StreamWriter writer= new StreamWriter(s);
            sw.AutoFlush = true;
            sw.WriteLine("hello world");`
