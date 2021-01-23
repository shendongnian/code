        class Program
        {
            private static bool terminated = false;
            private static void listen()
            {
                StreamReader file = new StreamReader(new FileStream("C:/test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                while (!terminated || !file.EndOfStream)
                    if (!file.EndOfStream)
                    {
                        string text = file.ReadLine();
                        MessageBox.Show(text); // display it
                    }
            }
            static void Main(string[] args)
            {
                FileStream file = new FileStream("C:/test.txt", FileMode.Create, FileAccess.Write, FileShare.Read);
                Console.SetOut(new StreamWriter(file));
                new Thread(new ThreadStart(listen)).Start();
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(250);
                    Console.Out.WriteLine("hello world - " + i);
                    Console.Out.Flush();
                }
                terminated = true;
            }
        }
