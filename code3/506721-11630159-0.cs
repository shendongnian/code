    private void button1_Click(object sender, EventArgs e)
    {
        string message = " ";
    
        for (int count = 0; count < numericUpDown1.Value; count++)
        {
            for (int m = 0; m < count; m++)
            {
                message += "*";
            }
            message += "\r\n"
        }
    }
