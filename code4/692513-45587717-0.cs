    private void Example_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            Task.Run(async () => await CreateAsync(listDomains)).Wait();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }
