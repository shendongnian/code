     var EntriesNotInB = firstDt.AsEnumerable().Select(r => r.Field<string>("abc")).Except(secondDt.AsEnumerable().Select(r => r.Field<string>("abc")));
            
            if (EntriesNotInB.Count() > 0)
            {
                DataTable dt = (from row in firstDt.AsEnumerable()join id in EntriesNotInB  on row.Field<string>("abc") equals id select row).CopyToDataTable();
                foreach (DataRow row in dt.Rows)
                {
                  /////Place your code to manipulate on datatable Rows
                }
            }
