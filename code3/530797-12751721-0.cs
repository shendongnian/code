      private void dataGridViewEnterTab1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewEnterTab1.IsCurrentRowDirty) // Trigger when the row is dirty or has changed
            {
                string userName = dataGridViewEnterTab1["UserNameCol", e.RowIndex].EditedFormattedValue.ToString();
                //...Your SqlDataAdapter or codes
            }
        }
