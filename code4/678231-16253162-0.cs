    private void button1_Click(object sender, EventArgs e)
    {
        if(textBox2.Text == string.Empty || textBox3.Text == string.Empty)
        {
          MessageBox.Show("Please Fill Both Text Box");
          return;
        }
        double A = double.Parse(textBox2.Text); 
        double B = double.Parse(textBox3.Text); 
        textbox4.Text = (A * B).ToString(); 
    }
