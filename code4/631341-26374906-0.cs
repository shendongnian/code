    enter code here
     private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Font = new Font("Your font", 10);
            }
            else 
            {
                textBox1.Font = new Font("Times New Roman", 10);
            }
        }
    
