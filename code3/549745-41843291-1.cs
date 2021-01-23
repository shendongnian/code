    public void Main(string[] args)
            {
                if (args.Count() > 0)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(args[0]);
                    MemoryStream stream = new MemoryStream(byteArray);
                    StreamReader sr = new StreamReader(stream);
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            }
