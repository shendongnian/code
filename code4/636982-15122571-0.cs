    private void button1_Click(object sender, EventArgs e)
    {
        int lineNumber;
        if (!int.TryParse(textBox2.Text, out lineNumber) || lineNumber < 0)
        {
            textBox1.Select(0, 0);
            return;
        }
    
        int position = textBox1.GetFirstCharIndexFromLine(lineNumber);
        if (position < 0)
        {
            // lineNumber is too big
            textBox1.Select(textBox1.Text.Length, 0);
        }
        else
        {
            int lineEnd = textBox1.Text.IndexOf(Environment.NewLine, position);
            if (lineEnd < 0)
            {
                lineEnd = textBox1.Text.Length;
            }
    
            textBox1.Select(position, lineEnd - position);
        }
    }
