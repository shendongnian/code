    <asp:FormView ID="formView1" runat="server" 
         OnItemUpdating="formView1_ItemUpdating" ...>
    protected void formView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
       var cblProducts = formView1.FindControl("cblProducts") as CheckBoxList;
    
       foreach (ListItem item in cblProducts.Items)
       {
           if (item.Selected)
           {
               // Check if item.Value is not in the db for this employee, if so add it
           }
           else
           {
               // Check if item.Value is in the db for this employee, if so delete it
           }
       }
    
       // save
    }
