    private bool button1WasClicked = false;
    
    private void button1_Click(object sender, EventArgs e)
    {
        button1WasClicked = true;
    }
     
    private void button2_Click(object sender, EventArgs e)
    {
        if (textBox2.Text == textBox3.Text && button1WasClicked)
        { 
            StreamWriter myWriter = File.CreateText(@"c:\Program Files\text.txt");
            myWriter.WriteLine(textBox1.Text);
            myWriter.WriteLine(textBox2.Text);
            button1WasClicked = false;
        }
    }
