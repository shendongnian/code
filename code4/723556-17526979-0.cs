    private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text);
            if (num1 < 0.0)
            {
                textBox1.Text = "Invalid Input";
                **buttonSquareRoot.Enabled = False;**
            }
            else
            {
                result = Math.Sqrt(double.Parse(textBox1.Text));
                textBox1.Text = Convert.ToString(result);
            }
        }
    private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            buttonSquareRoot.Enabled = True;
        }
