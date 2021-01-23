    protected void RGStyleGuideRestrictions_ItemCommand(object source, GridCommandEventArgs e)
    {
       ImageButton fired = source as ImageButton;
       if(fired!=null && fired.Id=="imgBtn1")
       {
          //imgBtn1 fired the command
       }
       else 
       {
         // and so on...
       }
       ImageButton imgBtn1 = e.item.FindControl("imgBtn1") as ImageButton;
       ImageButton imgBtn2 = e.item.FindControl("imgBtn2") as ImageButton;
    }
