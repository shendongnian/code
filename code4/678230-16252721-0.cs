    private void button1_Click(object sender, EventArgs e)
    {
        if(textBox2.Text == string.Empty || textBox3.Text == string.Empty)
        {
            MessageBox.Show("Invalid input");
            return;
        }
    
        double A = double.Parse(textBox2.Text); 
        double B = double.Parse(textBox3.Text); //gets the hourly wage
        double C = A * B; 
    }
