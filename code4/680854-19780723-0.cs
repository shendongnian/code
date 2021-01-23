      static void Main(string[] args)
        {
            Thread t1 = new Thread(Create);
            Thread t2 = new Thread(Delete);
            t1.Start();
            t2.Start();
        }
        private static void Create()
        {
            int i = 0;
            try
            {
                while (true)
                {
                    System.IO.TextWriter writer = new System.IO.StreamWriter("file.txt");
                    i++;
                    System.Console.Out.WriteLine(i);
                    writer.Write(i);
                    writer.Close();
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                System.Console.Out.WriteLine("Boom at: " + i.ToString());
            }
        }
        private static void Delete()
        {
            while (true)
            {
                try
                {
                    System.IO.File.Delete("file.txt");
                }
                catch (UnauthorizedAccessException ex)
                {
                }
                catch (Exception e)
                { }
            }
        }
