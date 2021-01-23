    void calculateProductTwoColumns(int castkaIndex, int pocetIndex, int tot_rows)
        {
            try
            {
                double outVal = 0; 
                foreach (DataGridViewRow row in dtg_ksluzby.Rows)
                {
                    outVal = outVal + Convert.ToDouble(row.Cells[castkaIndex].Value) * Convert.ToDouble(row.Cells[pocetIndex].Value);
                }
    
                kpriplac.Text = outVal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message.ToString());
            }
    
    
        }
