    public void dB10_TextChanged(object sender, EventArgs e)
    {
        voltage.TextChanged-= voltage_TextChanged;
        TextBox dB10 = sender as TextBox;
        double dBV;
        int i = dB10.Text.Trim().Length;
        if (i > 0)
        {
            dBV = Convert.ToDouble(dB10.Text);
        }
        else
            return;
       UnitConverter dBConverter = new UnitConverter();
       // Controls for if various radiobuttons were clicked
        if (dBVRadio.Checked == true)
        {
            dBV = dBConverter.dBVToVolts(dBV);
          
         }
        else if (dBuRadio.Checked == true)
        {
            dBV = dBConverter.dBuToVolts(dBV);
           
        } 
       voltage.Text = dBV.ToString();
       voltage.TextChanged+= voltage_TextChanged;
       
       
    }
