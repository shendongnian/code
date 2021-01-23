    static List<string> licensecAll = new List<string>();
    DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter("select * from [companies$]", testCnn);
                dp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = dt.Rows.Count-1; i >= 0; i--)
                    {
                        string lnum = dt.Rows[i][0].ToString();
                        Console.WriteLine("LICENSE NUMBER" + lnum);
                        if (!licensecAll.Contains(lnum))
                        {
                            Console.WriteLine("ROW REMOVED");
                            dt.Rows.RemoveAt(i);
                        }
                    }
   
                }
