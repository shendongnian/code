    <asp:Label ID="NumAccounts" runat="server" Text="# of Accounts"></asp:Label>      <asp:DropDownList
                ID="EmpNameList" runat="server" onselectedindexchanged="NumAccountsList_SelectedIndexChanged" 
                            AutoPostBack="True">
                 </asp:DropDownList>
        
         <div>
                <asp:PlaceHolder id="ContentPlaceHolder1" runat="server" />
            </div>
    protected void NumAccountsList_SelectedIndexChanged(object sender, EventArgs e)
        { 
                  ContentPlaceHolder1.Controls.Clear();
                   for(i=0; i<Convert.ToInt32(EmpNameList.SelectedItem.Value); i++)
                      {
    
                                   TextBox tx= new TextBox();
                                   tx.ID="tx"+i;
                                   ContentPlaceHolder1.Controls.Add(tx);
                                   ContentPlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                      }
    
        }  
   
