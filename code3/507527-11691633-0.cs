    <asp:GridView ID="grdCowCard" runat="server" Width="100%" 
            DataKeyNames="EventID,EventType" HeaderStyle-BackColor="#008B00" 
            OnRowCreated="grdCowCard_RowCreated" Caption="Lactation Records" 
            OnRowCommand="grdCowCard_RowSelected">
            <Columns>
              <asp:ButtonField Text="Select" CommandName="Select"/>  
            </Columns>
        </asp:GridView>
    protected void grdCowCard_RowSelected(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int RowIndex = int.Parse(e.CommandArgument.ToString());// Current row
            string id = grdCowCard.DataKeys[RowIndex]["EventID"].ToString();
            string eventType1 = grdCowCard.DataKeys[RowIndex]["EventType"].ToString();
            //grdCowCard.Attributes["ondblclick"] = string.Format("doubleClick({0})", id, eventType1);
            //id and eventType are passed to LactationDetails page, and used to determine which 
            //method to use and what data to retrieve
            Response.Redirect("LactationDetails.aspx?b=" + id + "&c=" + eventType1);
        }
    }
