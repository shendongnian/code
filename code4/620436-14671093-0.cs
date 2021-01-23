    private void btncalc_Click(object sender, EventArgs e)
    {
        try
        {
            int ina= numtea.Value;
            int inb= numcoffee.Value;
            int inc = 0, ind = 0;
            if (ina == 0 && inb == 0)  // this not working
            {
                MessageBox.Show("select a item");
                numtea.Focus();
            }
            if (cbxwithoutsugar.Checked)
            {
                inc = (ina * 20);
            }
            else
            {
                inc = (ina * 8);
            }
            if (cbxcoldcoffee.Checked)
            {
                ind = (inb * 10);
            }
            else
            {
                ind = (inb * 5);
            }
            txtamount.Text = (inc + ind).ToString();
        }    
    }
