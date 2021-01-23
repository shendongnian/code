    private void doThread2()
    {
        try
        {
            for (int j = 10000; j > 0; j--)
                textBox.Invoke(new Action(() => textBox.Text = j.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
