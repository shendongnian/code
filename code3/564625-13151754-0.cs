     <asp:Repeater ID='myRepeater' runat="server" OnItemDataBound='myRepeater_OnItemDataBound'>
              <ItemTemplate>
                <asp:HiddenField ID='myHidden' runat="server" />
                <asp:DropDownList ID="GeneralDDL" runat="server" AutoPostBack="True" />
        
              </ItemTemplate>
        </asp:Repeater>
    
    **Code behind :**
        protected void myRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                    var myHidden = (HiddenField)e.Item.FindControl("myHidden");
                            
                   foreach(RepeaterItem dataItem in 'myRepeater.Items)
                   {
                      myHidden.Value  = ((DropDownList)'myRepeater.FindControl("GeneralDDL")).SelectedItem.Text; 
    
                     // Same like for Text box              
                   }     
             }
