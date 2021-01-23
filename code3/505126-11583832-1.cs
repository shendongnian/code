    private void button1_Click(object sender, EventArgs e)
    {
        using (var dialog = new OpenFileDialog())
        {
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listbox.Items.AddRange(dialog.FileNames.Select(x => System.IO.Path.GetFileName(x)).ToArray());
            }
        }
    }
