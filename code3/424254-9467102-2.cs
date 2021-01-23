      <telerik:GridTemplateColumn UniqueName="TemplateColumn">
            <ItemTemplate>                
                <asp:ImageButton CommandArgument="btn1" ID="imgBtn1" runat = "server"/> 
                <asp:ImageButton CommandArgument="btn2" ID="imgBtn2" runat = "server"/>                     
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    protected void RGStyleGuideRestrictions_ItemCommand(object source, GridCommandEventArgs e)
    {
    
       if(e.CommandArgument=="btn1")
       {
          //imgBtn1 fired the command
       }
       else if(e.CommandArgument=="btn2")
       {
          //imgBtn2 fired the command  
       }
       ImageButton imgBtn1 = e.item.FindControl("imgBtn1") as ImageButton;
       ImageButton imgBtn2 = e.item.FindControl("imgBtn2") as ImageButton;
    }
