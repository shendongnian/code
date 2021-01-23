    private void button1_Click(object sender, EventArgs e)
    {
        string message = "";
        for (int count = 1; count < numericUpDown1.Value + 1; count++)
        {
             message += "".PadLeft(count,'*') + Environment.NewLine;      
        }
    }
