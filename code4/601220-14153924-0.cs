       public  void gdView_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                
                if (e.CommandName == "sendvalue")
                {
                    
                    for (int i = 0; i < gdView.Rows.Count; i++)
                    {
                        int getrow = Convert.ToInt32(e.CommandArgument);
        
                        HiddenField HiddenField1 = (HiddenField)gdView.Rows[getrow].FindControl("HiddenField1");
    }
    }
