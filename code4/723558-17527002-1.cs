    private void buttonSquareRoot_Click(object sender, EventArgs e)
    {
        num1 = double.Parse(textBox1.Text);
        if (num1 < 0.0)
        {
            textBox1.Text = "Invalid Input";
            SetControlsAbility(false);
        }
        else
        {
            result = Math.Sqrt(double.Parse(textBox1.Text));
            textBox1.Text = Convert.ToString(result);
        }
    }
