    private void vypocti_odvody(int price, int vat, int tot_rows2)
        {
            try
            {
            double outVal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double localSum = (Convert.ToDouble(row.Cells[price].Value)/100) * Convert.ToDouble(row.Cells[vat].Value) + (Convert.ToDouble(row.Cells[price].Value));
                outVal = outVal + localSum;
                row.Cells[sumcolumn].Value = localSum;
            }
            Convert.ToDecimal ( result.Text = outVal.ToString()) ;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Chybové hlášení K3 " + ex.Message.ToString());
        }
    }
