    using (StreamReader sr = new StreamReader(@"C:\Users\Username\Documents\a.txt"))
    using (StreamWriter sw = new StreamWriter(@"C:\Users\Username\Documents\b.txt"))
    {
        int counter = 0;
        string line = String.Empty;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("="))
            {
               sw.WriteLine(line);
               if (++counter == 4)
               {
                  sw.WriteLine();
                  counter = 0;
               }
            }
        }
    }
