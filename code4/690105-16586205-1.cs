    protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper().ToString() == "DELETEREC")
        {
            try
            {
                int index = gridview1.SelectedIndex;
    
                int ID = Convert.ToInt32(gridview1.DataKeys[index].Value.ToString());
    
                int r = Namespace.SPs.StoredProcedure(ID ).Execute();
                // do stuff 
            }
            catch (SqlException ex)
            {
                ClientMessaging(ex.Message);
            }
        }
    }
