    protected void Button1_Click(object sender, EventArgs e) 
    {
        var literals = this.Controls.FindAll<Literal>();
        foreach (Literal literal in literals)
        {
            literal.Text = "Your Text";
        }
    }
