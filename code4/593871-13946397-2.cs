    string input = textBox1.Text;
    StringBuilder output = new StringBuilder(input.Length);
    bool inATag = false;
    
    for (var i = 0; i < input.Length; i++) {
        if (!inATag && input[i] != '>' && input[i] != '<') {
            output.Append(input[i]);
        } else if (input[i] == '<') {
            inATag = true;
        } else if (input[i] == '>') {
            inATag = false;
        }
    }
    textBox2.Text = output.ToString();
