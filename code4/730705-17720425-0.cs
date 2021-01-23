     for (int i = 0; i < dtg_ksluzby.Rows.Count; i++)
            {
                var row = dtg_ksluzby.Rows[i];
                using(var novyprikaz2 = new SqlCommand("SELECT * FROM klient WHERE ID_K=" + vyberradek, spojeni))
                {
                    spojeni.Open();
                    SqlDataReader precti2 = novyprikaz2.ExecuteReader();
                    if (precti2.HasRows)
                    {
                        row.Cells[3].Value = true;
                    }
                }
            }
