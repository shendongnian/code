    Private void CB1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Combobox CB = (ComboBox) sender;
        if(CB.SelectedIndex != -1)
        {
            int x = Convert.ToInt32(CB.Text)
            if(x == 3)
            {
              CB2.Visible = True;
            }
        }
    }
