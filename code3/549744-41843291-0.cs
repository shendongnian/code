    public void Main(string[] args)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(args[0]);
                MemoryStream stream = new MemoryStream(byteArray);
    
                StreamReader sr = new StreamReader(stream);
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
