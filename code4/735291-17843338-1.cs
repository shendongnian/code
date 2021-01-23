    public int LineCounter()
        {
            using (StreamReader myRead = new StreamReader(@"C:\TestFiles\test.txt"))
            {
                int lineCount = 0;
                string line;
    
                while ((line = myRead.ReadLine()) != null)
                {
                    if (line.Count() != 0)
                    {
                        lineCount++;
                    }
                }
            }
    
            return lineCount;
        }
