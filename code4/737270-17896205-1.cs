    protected void lst_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detail")
        {
            int index = e.Item.ItemIndex;
    
            for (int i = 0; i < lst.Items.Count; i++)
            {
                LinkButton btnlnk = lst.Items[i].FindControl("lnk") as LinkButton;
                if (btnlnk !=null)
                {
                    btnlnk.CssClass = index == i? "selectedclass" :string.Empty;
                }
                        
            }
                    
        } 
    }
