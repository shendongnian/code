            for (int i = 0; i < dtg_ksluzby.Rows.Count; i++)
            {
                var row = dtg_ksluzby.Rows[i];
                using(var novyprikaz2 = new SqlCommand("SELECT pocet FROM klisluz WHERE text=@t AND subkey=@s", spojeni))
                {
                    novyprikaz2.Parameters.AddWithValue("@t", row.Cells["text"].Value.ToString());
                    novyprikaz2.Parameters.AddWithValue("@s", vyberradek);
                    spojeni.Open();
                    SqlDataReader precti2 = novyprikaz2.ExecuteReader();
                    if (precti2.Read())
                    {
                        row.Cells["pocet"].Value = precti2["pocet"];
                    }
                }
            }
