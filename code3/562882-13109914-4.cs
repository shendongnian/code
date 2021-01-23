    private void ShowDecimal_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            decimal dec = Convert.ToDecimal("3.1922");
            MessageBox.Show(dec.ToString());
        }
