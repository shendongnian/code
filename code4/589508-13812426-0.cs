    int clicked = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        clicked = Convert.ToInt32(((Button)sender).Text);
        lstFrequencies.Items.Add(((Button)sender).Name + " " + ++clicked);
        button1.Text = clicked.ToString();  // you lose this line
    }
