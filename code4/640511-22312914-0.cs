                string[] restrictions = new string[] { null, null,   strTable };
                DataTable tableInfo = Connection.GetSchema("IndexColumns", restrictions);
                if (tableInfo == null)
                    throw new Exception("TableInfo null Error");
                
                foreach (DataRow test in tableInfo.Rows)
                {
                    Console.WriteLine(test["column_name"]);             
                }
