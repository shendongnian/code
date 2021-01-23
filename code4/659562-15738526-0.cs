    <asp:Literal ID="ltrlMessages" runat="server"></asp:Literal>
    protected void Button1_Click(object sender, EventArgs e)
    {
        ltrlMessages.Text = "status message one";
        //
        //executes some statements
        //
        ltrlMessages.Text += "</br> status message two";
        //
        //some other statements
        //
        ltrlMessages.Text += "</br> status message three and so on";
        
    }
