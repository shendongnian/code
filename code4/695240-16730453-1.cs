    converter.CopyComplete += new converter.OnCopyComplete(UpdateMyLabels);
    converter.convert(....);
    public void UpdateMyLabels(string file)
    {
        TextBox1.Text = "File Copied" + "  " + DateTime.Now.ToString("HH:mm:ss tt") + Environment.NewLine;
    }
