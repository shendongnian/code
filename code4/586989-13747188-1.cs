    Public void addRows()
        {
            var sr = new StreamReader(@"C:\DataColumnTest.txt");
    
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (!String.IsNullOrEmpty(s.Trim()))
                {
                    data = null;
                    data = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    dt.Rows.Add(data);
                }
    
            }
    
            sr.Close();
        }
