     // On Page1.aspx I have a button for postback
      <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
         PostBackUrl="~/Page2.aspx" />
     // Page1.aspx.cs 
     protected void Page_Load(object sender, EventArgs e)
     {
        TextBox t = new TextBox(); // created a TextBox
        t.ID = "myTextBox";        // assigned an ID
        form1.Controls.Add(t);     // Add to form
    }
