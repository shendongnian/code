    public void addcolumns()
            {
    
                using (StreamReader reader = new StreamReader(@"C:\DataColumnTest.txt"))
                {
                    string s = reader.ReadLine();
                    string[] col = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
    
                    foreach (var a in col)
                    {
                        dt.Columns.Add(new DataColumn());
                    }
                }
            }
