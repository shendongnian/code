        <asp:DropDownList ID="ddlLanguage" class="langpnl" runat="server" AutoPostBack="False">
            <asp:ListItem Value="en-US">Eng</asp:ListItem>
            <asp:ListItem Value="es-ES">Esp</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="myHiddenButton" runat="server" Style="display: none;" OnClick="myHiddenButton_Click" />
    void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string message = "Some Content of the Site are only in English. Do you want to continue?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("if confirm('");
            sb.Append(message);
            sb.Append("') ");
            sb.AppendFormat("document.getElementById('{0}').click();", this.myHiddenButton.ClientID);
            //Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
            // write your js as the client-side onchange handler on the ddl
            this.ddlLanguage.Attributes["onchange"] = sb.ToString();
            //alert end
        }
        this.myHiddenButton.Click += new EventHandler(myHiddenButton_Click);
    }
    void myHiddenButton_Click(object sender, EventArgs e)
    {
        // only ever called if user confirms the js prompt
        //Sets the cookie that is to be used by Global.asax
        HttpCookie cookie = new HttpCookie("CultureInfo");
        cookie.Value = ddlLanguage.SelectedValue;
        Response.Cookies.Add(cookie);
        //Set the culture and reload the page for immediate effect. 
        //Future effects are handled by Global.asax
        Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlLanguage.SelectedValue);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlLanguage.SelectedValue);
        Server.Transfer(Request.Path);
    }
