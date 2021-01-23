    StreamWriter file = new StreamWriter(@"c:\Error.txt",false);
    List<string> error = new List<string>();
              foreach (DataRow row in dt.Rows)
              {
                            try
                            {
                                UpdateEvent(LN);
                            }
                            catch (Exception e)
                            {
                                error.Add(String.Format("Exception for Loan Number {0} with a Error {1}", row["LN"].ToString(), e.ToString()));
                                //continue; 
                             }
                            try
                            {
                                insertevent(LN, note);
                            }
                            catch (Exception e)
                            {
                                error.Add(String.Format("Exception for Loan Number {0} with a Error {1}", row["LN"].ToString(), e.ToString()));
                                //continue; 
                             }
                }
    
                foreach (string line in error)
                {
                    file.WriteLine(line);
                }
