            var dt = new DataTable();
            var iFila = vals.GetLongLength(0);
            var iCol = vals.GetLongLength(1);
            for (var f = 1; f < iFila; f++)
            {
                var row = dt.Rows.Add();
                for (var c = 1; c <= iCol; c++)
                {
                    if (f == 1) 
                        dt.Columns.Add(vals[1, c] != null 
                            ? vals[1, c].ToString() 
                            : "");
                    row[vals[1, c].ToString()] = vals[f, c];
                }
            }
