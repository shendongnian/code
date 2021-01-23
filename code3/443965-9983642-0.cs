    public String Value
    {
        get;
        set;
    }
  
    protected void BtnTransfer_Click(object sender, EventArgs e)
    {
        Value = "Foo";
        Server.Transfer("Transfer.aspx");
    }
