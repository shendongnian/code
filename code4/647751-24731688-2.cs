    protected void Button1_Click(object sender, EventArgs e)
    {
        int i;
        if (!int.TryParse(textBox.Text, out i))
        {
            Label.Text = "This is a number only field";
            return;
        }
    }
