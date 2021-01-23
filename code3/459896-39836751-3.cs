    private void button1_Click(object sender, EventArgs e)
    {
        
        if (!double.TryParse(textBox1.Text, out var x))
        {
            System.Console.WriteLine("it's not a double ");
            return;
        }
        System.Console.WriteLine("it's a double ");
    }
