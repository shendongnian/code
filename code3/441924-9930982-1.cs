    protected override void RaisePostBackEvent(IPostBackEventHandler source, string eventArgument)
    {
        base.RaisePostBackEvent(source, eventArgument);
        if (source == GridView1)
        {
            int rowIndex = int.Parse(eventArgument);
            TextBox txt = GridView1.Rows[rowIndex].FindControl("TextBox1") as TextBox;
            if (txt != null)
            {
                var id = (int)GridView1.DataKeys[rowIndex]["ID"];
                var text = txt.Text.Trim();
                //update the database
            } 
        }    
    }
