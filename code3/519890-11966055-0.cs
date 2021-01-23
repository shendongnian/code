    using (OleDbConnection cn = new OleDbConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\path\file.xls" + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Sheet1$]";
                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        using (StreamWriter wr = new StreamWriter(@"C:\path\flie.tsv"))
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                wr.WriteLine(row[0] + "\t" + row[1]);
                            }
                        }
                    }
                }
            }
