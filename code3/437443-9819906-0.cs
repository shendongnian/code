    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
           d = new divide(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
           int total = d.CalculateDivision();
           MessageBox.Show(total.ToString());
        }
        catch(Exception error)
        {
            MessageBox.Show(error.Message);
        }
    }
