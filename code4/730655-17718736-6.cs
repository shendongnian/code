     for (int i = 0; i < dtg_ksluzby.Rows.Count; i++)
            {
                var row = dtg_ksluzby.Rows[i];
                SqlCommand novyprikaz2 = new SqlCommand("SELECT pocet FROM klisluz WHERE text='" + row.Cells["text"].Value + "' AND subkey='" + vyberradek + "'",spojeni);
                spojeni.Open(); 
                SqlDataReader precti2 = novyprikaz2.ExecuteReader();
                if (precti2.Read())
                {
                    row.Cells["pocet"].Value = precti2["pocet"];
                }
            }
