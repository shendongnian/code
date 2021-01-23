    void button1_Click(object sender, EventArgs e)
    {
        foreach (var c in AllControls(this).OfType<TextBox>())
        {
            if ((string) c.Tag == "Filled")
            {
                // Here is where you put your code to do something with Textbox 'c'
            }
        }
    }
