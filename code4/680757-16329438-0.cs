    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = int.Parse(textBox1.Text);  //here's your value
                label1.Text = num.ToString();
            }
            catch (Exception exc)
            {
                label2.Text = exc.Message;
            }
        }
