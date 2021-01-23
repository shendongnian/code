    string name = textBox1.Text;
    int min = int.Parse(textBox2.Text);
    int max = int.Parse(textBox3.Text);
    textBox4.Text = string.Join(Environment.NewLine, 
        Enumerable.Range(min, max - min + 1).Select(i => name + i));
    
