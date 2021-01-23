           private void dataGridView_BadgeService_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView_BadgeService.Columns[e.ColumnIndex].Name == "DateDebut" || dataGridView_BadgeService.Columns[e.ColumnIndex].Name == "DateFin")
            {
                string date = Convert.ToString(e.FormattedValue).Trim();
                if (date.Length > 0)
                {
                    try
                    {
                        DateTime _date;
                        if (DateTime.TryParse(date, out _date) == false)
                        {
                            if (DateTime.TryParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _date) == false)
                            {
                                MessageBox.Show("Merci de saisir une date, ou laissez cette zone vierge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }
                            else
                            {
                                dataGridView_BadgeService.CancelEdit();
                                e.Cancel = false;
                            }
                        }
                        else
                        {
                            dataGridView_BadgeService.CancelEdit();
                            e.Cancel = false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Merci de saisir une date, ou laissez cette zone vierge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }
                                            
