    StringBuilder sb = new StringBuilder();
    
                string[] val =  { "ramesh","suresh, Ganesh" };
                IEnumerable<string> columnNames = val;
    
                IList<string> objFinal = new List<string>();
                foreach (string v in columnNames)
                {
                    string temp = v;
                    if (temp.Contains(","))
                        temp = "\"" + v + "\"";
    
                    objFinal.Add(temp);
                }
                sb.AppendLine(string.Join(",", objFinal.AsEnumerable<string>()));
                    
                }            
