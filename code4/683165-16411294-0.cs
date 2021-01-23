    string line15=GetLine(@"test.txt",15);
    public string GetLine(string fileName, int line)
        {
            using (System.IO.StreamReader ssr = new System.IO.StreamReader("test.txt")) 
           //using (var ssr = new StreamReader("test.txt"))
            {
                for (int i = 1; i < line; i++)
                    ssr.ReadLine();
                return ssr.ReadLine();
            }
        }
