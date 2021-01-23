    using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            dt.Columns[0].ColumnName = "Item NO";
                            dt.Columns[1].ColumnName = "LocalCode";                       
                            dt.Columns[2].ColumnName = "Currency";
                            dt.Columns[3].ColumnName = "Menu Flag";
                            dt.Columns[4].ColumnName = "Item Class";
                            dt.Columns[4].ColumnName = "Dress Sort";
                            return dt;
                        }
