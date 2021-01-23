    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (TextBox tb in this.Controls.OfType<TextBox>())
        {
            tb.Enter += new EventHandler(textBoxAll_Enter);
            tb.Leave += new EventHandler(textBoxAll_Leave);
        }
    }
    
    private void textBoxAll_Enter(object sender, EventArgs e)
    {
        ((TextBox)sender).Text = "textbox gained focus";
    }
    
    private void textBoxAll_Leave(object sender, EventArgs e)
    {
        ((TextBox)sender).Text = "textbox lost focus";
    }
