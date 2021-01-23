    void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label test = (Label)e.Item.FindControl("Label1");
            
            Literal literal1 = new Literal();
            literal1.Text = "<strong>";
    
            e.Item.Controls.AddAt(e.Item.Controls.IndexOf(test), literal1);
    
            Literal literal2 = new Literal();
            literal2.Text = "</strong>";
    
            e.Item.Controls.AddAt(e.Item.Controls.IndexOf(test) + 1, literal2);
        }
    }
