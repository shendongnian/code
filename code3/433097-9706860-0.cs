    protected void Page_Load(object sender, EventArgs e)
    {
        rblCreat.Items[0].Attributes.Add("onclick", "abc('1');");
        rblCreat.Items[1].Attributes.Add("onclick", "abc('2');");
        rblCreat.Items[2].Attributes.Add("onclick", "abc('3');");
    }
