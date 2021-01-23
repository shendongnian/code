        private void AlternatingRows()
        {
            foreach (DataGridViewRow row in dataGridView_daten.Rows)
            {
                if (row.Index > 0)
                {
                    if (row.Cells[0].Value.ToString().Substring(0, 5) != dataGridView_daten.Rows[row.Index - 1].Cells[0].Value.ToString().Substring(0, 5))
                    {
                        if (Farbe == Color.FromArgb(226, 241, 254))
                            Farbe = Color.AliceBlue;
                        else
                            Farbe = Color.FromArgb(226, 241, 254);
                    }
                    row.DefaultCellStyle.BackColor = Farbe;
                }
            }
        }
