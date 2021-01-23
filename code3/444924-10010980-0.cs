    public void Page_Load(object sender, EventArgs e) {
        if(!IsPostback && OnlyOneItem) {
            Server.Transfer("TheOtherPage.aspx");
        }
    }
