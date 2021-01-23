    private void BtnScrambleText_Click(object sender, EventArgs e)
    {
        textBox1.Enabled = false;
        BtnScrambleText.Enabled = false;
        
        StringBuilder sb = new StringBuilder();
        var words = Regex.Split(textBox1.Text, @"(?=(?<=[^\s])\s+)");
        foreach (string word  in words)
        {
            ScrambleTextBoxText scrmbltb = new ScrambleTextBoxText(word.Trim());
            scrmbltb.GetText();
            sb.Append(word.Replace(word.Trim(), scrmbltb.scrambledWord));
        }
        textBox2.AppendText(sb.ToString());
    }
