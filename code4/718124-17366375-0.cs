    Markup:
    <asp:gridview id="ContactsGridView" datasourceid="ContactsSource" allowpaging="true" 
        autogeneratecolumns="false" onrowcommand="ContactsGridView_RowCommand" runat="server">
        <columns>
           <asp:buttonfield buttontype="Link" commandname="Add" text="Add"/>
           <asp:boundfield datafield="ContactID" headertext="Contact ID"/>
           <asp:boundfield datafield="FirstName" headertext="First Name"/> 
           <asp:boundfield datafield="LastName" headertext="Last Name"/>
        </columns>
    </asp:gridview>
    Code-Behind:
    void ContactsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if(e.CommandName=="Add")
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);
            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.
            GridViewRow row = ContactsGridView.Rows[index];
            // Create a new ListItem object for the contact in the row.     
            ListItem item = new ListItem();
            item.Text = Server.HtmlDecode(row.Cells[2].Text) + " " +
            Server.HtmlDecode(row.Cells[3].Text);
            // If the contact is not already in the ListBox, add the ListItem 
            // object to the Items collection of the ListBox control. 
            if (!ContactsListBox.Items.Contains(item))
            {
                ContactsListBox.Items.Add(item);
            }
        }
    }
