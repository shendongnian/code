            if (string.IsNullOrWhiteSpace(row.Cells["CellNumber"].EditedFormattedValue.ToString()))
            {
                MessageBox.Show("Please enter cellnumber", "Missing Information");
                return;
            }
