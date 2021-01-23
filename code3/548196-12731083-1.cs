    private void InsertList(IEnumerable<String> list)
    {
        String sql = "INSERT INTO dbo.Table VALUES(@varcharCol,@dateCol,@decCol1,@decCol2,@decCol3,@decCol4,@intCol);";
        using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
        {
            con.Open();
            foreach (String str in list)
            {
                String[] fields = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length == 7)
                { 
                    DateTime dateCol;
                    if (DateTime.TryParseExact(fields[1], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dateCol))
                    {
                        decimal d1, d2, d3, d4;
                        int i1;
                        if(decimal.TryParse(fields[2], out d1)
                            && decimal.TryParse(fields[3], out d2)
                            && decimal.TryParse(fields[4], out d3)
                            && decimal.TryParse(fields[5], out d4)
                            && int.TryParse(fields[6], out i1))
                        {
                            using(var cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@varcharCol", fields[0]);
                                cmd.Parameters.AddWithValue("@dateCol", dateCol);
                                cmd.Parameters.AddWithValue("@decCol1", d1);
                                cmd.Parameters.AddWithValue("@decCol2", d2);
                                cmd.Parameters.AddWithValue("@decCol3", d3);
                                cmd.Parameters.AddWithValue("@decCol4", d4);
                                cmd.Parameters.AddWithValue("@intCol", i1);
                                int inserted = cmd.ExecuteNonQuery(); // should be 1
                            }
                        }
                    }
                }
            }
        }
    }
