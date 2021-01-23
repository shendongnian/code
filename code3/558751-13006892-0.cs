    // These are your outputs from that SP
    int MaxPageNumber = 10,
        CurrentPageNumber = 4;
    
    void BindPager()
    {
        DataTable PagerData = new DataTable();
        PagerData.Columns.Add("pageNo");
        for (int i = 1; i < MaxPageNumber; i++)
          PagerData.Rows.Add(i);
        pager.DataSource = PagerData;
        pager.DataBind();
    }
    
    <asp:Repeater runat="server" ID="pager" onitemcommand="pager_ItemCommand" 
            onitemdatabound="pager_ItemDataBound">
       <ItemTemplate>
           <asp:Button runat="server" ID="pageNo" 
                       Text='<%# Eval("pageNo") %>' 
                       CommandArgument='<%# Eval("pageNo") %>'
                       CommandName="DoPaging" />
       </ItemTemplate>
    </asp:Repeater>
    
    
    protected void pager_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      // Code to highlight current page
      if (e.Item.ItemType == ListItemType.Item || 
          e.Item.ItemType == ListItemType.AlternatingItem)
      {
         Button pageNo = e.Item.FindControl("pageNo") as Button;
         if (pageNo == null) return;
         if (pageNo.Text == CurrentPageNumber.ToString())
            pageNo.BackColor = Color.Blue;
         else
            pageNo.BackColor = Color.Gray;
      }
    }
    
    protected void pager_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      // perform your paging here according to page number
    }
