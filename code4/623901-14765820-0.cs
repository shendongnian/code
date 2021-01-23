    using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\LanmanServer\Parameters"))
    if (Key != null)
    {
        var val = Key.GetValue("EnableOplocks");
        if (val == null)
        {
            oplockTextBox.Text = "Not Present In Registry";
            oplockTextBox.BackColor = Color.Yellow;
        }
        else if (val.ToString() == "1")
        {
            opslockTextBox.Text = "NO";
            opslockTextBox.BackColor = Color.Red;
        }
        else
        {
            oplockTextBox.Text = "YES";
            oplockTextBox.BackColor = Color.Green;
        }
    }
    else
    {
        MessageBox.Show("");
    }
