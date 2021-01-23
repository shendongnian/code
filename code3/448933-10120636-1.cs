    public Stack<string> Undo { get; set; } // needs to be initialized before use
    private void button1_Click(object sender, EventArgs e)
    {
                if (string.IsNullOrEmpty(textBox1.Text))
                    return;
    
                Undo.Push(textBox1.Text);
    }
    
    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
                if (e.KeyCode != Keys.Up)
                    return;
    
                if (Undo.Count == 0)
                    return;
    
                textBox2.Text = Undo.Pop();
    }
