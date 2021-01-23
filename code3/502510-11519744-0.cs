      string[] name = "A,B,C,D".Split(',');
               string[] value = "100,200,300,400".Split(',');
                 DataTable tbl = new DataTable();
                 tbl.Columns.Add("name", typeof(string));
                 tbl.Columns.Add("value", typeof(string));
                for( int i=0; i<name.Length;i++)
                {
                    
                     tbl.Rows.Add(name[i],value[i]);
                }
