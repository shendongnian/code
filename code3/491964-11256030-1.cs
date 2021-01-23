    if (name.Contains("l"))
    {
        name = name.Replace("l", "s");
        textBox1.Text = name;
    }
    MessageBox.Show(name);
