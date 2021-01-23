    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detail")
        {
            int index = e.Item.ItemIndex;
    
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                LinkButton btnlnk = DataList1.Items[i].FindControl("lnk") as LinkButton;
                if (btnlnk !=null)
                {
                    btnlnk.CssClass = e.Item.ItemIndex == i? "selectedclass" :string.Empty;
                }
                        
            }
                    
        } 
    }
