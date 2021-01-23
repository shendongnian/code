    private void button1_Click(object sender, EventArgs e)
    {
        
        if (!double.TryParse(textBox1.Text, out double myX))
        {
            System.Console.WriteLine("it's not a double ");
            return;
        }
        else 
            System.Console.WriteLine("it's a double ");
    }
