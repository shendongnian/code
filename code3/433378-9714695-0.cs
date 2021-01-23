    <asp:DataList ID="dlSample" runat="server" OnItemDataBound="dlSample_ItemDataBound">
         <ItemTemplate>
              <asp:Label ID="lbl" runat="server"></asp:Label>
          </ItemTemplate>
    </asp:DataList>
    
    protected void dlSample_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //dataitem is supposed to be a string object, so you can cast it to string, no need to call ToString()
            var item = (string)e.Item.DataItem;
            
            // find the label with "lbl" ID, use e.Item as the Naming Container
            var lbl = (Label)e.Item.FindControl("lbl");
            if (item == "1")
               lbl.Text = "one";
            else
               lbl.Text = item;
        }
