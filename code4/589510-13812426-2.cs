    int clicked = 0;
    private void button1_Click(object sender, EventArgs e)
    {
       // if you want to display button name, change .Text to .Name
       lstFrequencies.Items.Add(((Button)sender).Text + " " + ++clicked);
    }
