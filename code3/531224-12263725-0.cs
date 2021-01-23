        try
        {
            if (Properties.Settings.Default["Database"] != null)
            {
                MessageBox.Show("We landed on spot 1");
            }
            else
            {
                MessageBox.Show("We landed on spot 2");
            }
        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
        }
