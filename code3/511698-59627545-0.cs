                var dir = @"D:\New folder\log";  // folder location
    
                if (!Directory.Exists(dir))  // if it doesn't exist, create
                    Directory.CreateDirectory(dir);
     
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        result.Append(row[i].ToString());
                        result.Append(i == dt.Columns.Count - 1 ? "\n" : ",");
                    }
                    result.AppendLine();
                }
                string path = System.IO.Path.Combine(dir, "item.txt");
                StreamWriter objWriter = new StreamWriter(path, false);
                objWriter.WriteLine(result.ToString());
                objWriter.Close();
