       for (int i = 0; i < dtg_ksluzby.Rows.Count;i++)
            {
                var row = dtg_ksluzby.Rows[i];
                int id = (int)row.Cells["ID"].Value;
                using (var novyprikaz3 = new SqlCommand("SELECT * from klisluz WHERE subkey= '" + vyberradek + "' AND IDzajsluz=" + id , spojeni))
                {
                    spojeni.Open();
                    SqlDataReader precti3 = novyprikaz3.ExecuteReader();
                    if (precti3.HasRows)
                    {
                        row.Cells[4].Value = true;
                    }
                    spojeni.Close();
                }
            }
