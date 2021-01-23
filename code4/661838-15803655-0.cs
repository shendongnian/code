    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            textBox2.Text = (result == DialogResult.OK) ? fbd.SelectedPath : string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
