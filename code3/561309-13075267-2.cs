    // Save the regular expression object globally (so it won't be created every time the text is changed).
    Regex reg = new Regex(@"[^\d]");
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (reg.IsMatch(textBox1.Text))
            textBox1.Text = reg.Replace(textBox1.Text, ""); // Replace only if it matches.
    }
