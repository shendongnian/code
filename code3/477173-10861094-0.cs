    <asp:RadioButtonList id="docList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="loginUser" />
    public string SelectedDoc {get;set;}
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack){
       }
       else
       {
          SelectedDoc = docList.SelectedValue; //this will be set on postback and will contain the selected value.
       }
    }
