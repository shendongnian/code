        using (StreamWriter sw = new StreamWriter("C:\\Temp\\Test.txt")) 
        {
         DataSet ds = GetData(); //call sproc, return data
         foreach(DataRow dr in ds.Rows) 
         {
           var column = string.IsNullOrEmpty((dr["MemoColumn"].ToString()) ? string.Empty : 
                        dr["MemoColumn"].ToString().Replace(Environment.NewLine, string.Empty);
           sw.WriteLine("{0}|{1}|{2}", dr["Column1"], column, dr["Column3"]);
         }
        }
