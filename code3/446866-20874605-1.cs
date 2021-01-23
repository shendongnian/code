    private void dataGridSMS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridSMS.Columns[e.ColumnIndex].Name == "dateColumn")
            {
                if (e.Value != null)
                {
                    try
                    {
                        // Formatting
                        double timestamp = Convert.ToDouble(e.Value); // if e.Value is string you must parse
                        System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                        dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
                        e.Value = dateTime.ToString();
                        e.FormattingApplied = true;
                    }
                    catch (Exception)
                    {
                        e.FormattingApplied = false;
                    }
                }
            }
        }
