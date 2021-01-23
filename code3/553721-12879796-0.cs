    <asp:Button ID="btnstatus" CommandName="ChangeStatus" 
    runat="server" Text='<%#Bind("fld_status")%>' />
      void ItemsGrid_Command(Object sender, DataGridCommandEventArgs e)
      {
         switch(((Button)e.CommandSource).CommandName)
         {
            case "ChangeStatus":
             // Add your code here
               break;
            default:
               // Do nothing.
               break;
         }
      }
