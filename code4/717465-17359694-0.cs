     private void dataGridView_BadgeService_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_BadgeService.Columns[e.ColumnIndex].Name == "DateDebut" || dataGridView_BadgeService.Columns[e.ColumnIndex].Name == "DateFin")
            {
                string date = Convert.ToString(dataGridView_BadgeService.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Trim();
                if (date.Length > 0)
                {
                    try
                    {
                        DateTime _date;
                        if (DateTime.TryParse(date, out _date) == true)
                        {
                            dataGridView_BadgeService.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _date.ToShortDateString();
                        }
                        else
                        {
                            if (DateTime.TryParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _date) == true)
                            {
                                dataGridView_BadgeService.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _date.ToShortDateString();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Merci de saisir une date, ou laissez cette zone vierge", "Action-Informatique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
        }
