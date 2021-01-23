    foreach (string item in attend)
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@Name", item));
                    cmd.Parameters.Add(new SqlParameter("@Course", attender.SelectedValue));
                    cmd.ExecuteReader();
                    con.Close();
                }
