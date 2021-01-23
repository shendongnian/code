    foreach (string item in attend)
                {
                    con2.Open();
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add(new SqlParameter("@Name", item));
                    cmd2.Parameters.Add(new SqlParameter("@Course", attender.SelectedValue));
                    cmd2.ExecuteReader();
                    con2.Close();
                }
