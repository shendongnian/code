    protected override void OnLoad(EventArgs e)
    {
        Literal literal = new Literal();
        this.placeHolder.Controls.Add(literal);
        if (!this.IsPostBack)
            literal.Text = "I'm still here after a postback.";
    }
