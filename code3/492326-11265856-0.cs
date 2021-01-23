    public Boolean lastCharIsSymbol {get;set;}
    private void button9_Click(object sender, EventArgs e)
    {
        textBox1.Text = textBox1.Text + "9";
        lastCharIsSymbol = false;
    }
    private void buttonPlus_Click(object sender, EventArgs e)
    {
        if (textBox1.Text == "" || lastCharIsSymbol)
            return;
        else
        {
            plus = true;
            textBox1.Text = textBox1.Text + " + ";
            lastCharIsSymbol = true;
        }
    }
