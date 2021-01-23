    void GridView1_RowCommand( object sender, GridViewCommandEventArgs e )
    {
        if ( e.CommandName == "LinkButtonClicked" )
        {
            string id = e.CommandArgument; // this is the ID of the clicked item
        }
    }
