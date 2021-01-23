    private void textbox1_TextChanged(object sender, EventArgs e)
        {
            if (textbox1.Text != "" & textbox1.Text != "-")
            {
                p1 = double.Parse(textbox1.Text);
            }
        }
