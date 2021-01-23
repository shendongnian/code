    string text = textBox1.Text;
        
    string[] words = text.Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries);
        
    foreach (string word in words)
    {
        textBox2.Text += " " + ChangeWord(word);
    }
