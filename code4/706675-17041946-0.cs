            DataSet ds = new DataSet();
            DataTable dt = ds.Tables[0]; 
             
                foreach (DataColumn dc in dt.Columns)
                {
                    Console.WriteLine(dc.DataType);
                }
