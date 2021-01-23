    private void projectNameBox_TextChanged(object sender, EventArgs e)
    {
        TextBox textbox = sender as TextBox;
        string invalid = new string(System.IO.Path.GetInvalidFileNameChars());
        Regex rex = new Regex("[" + Regex.Escape(invalid) + "]");
        textbox.Text = rex.Replace(textbox.Text, "");
    }
