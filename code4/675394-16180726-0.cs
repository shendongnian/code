    GridViewRow row = GridView1.SelectedRow;
    string entityID = row.Cells[1].Text;
        
    switch (row.RowIndex)
    {
        case 1:
            Response.Redirect("gamers.aspx?EntityID=" + entityID);
            break;
        case 2:
            Response.Redirect("audio.aspx?EntityID=" + entityID);
            break;
    }
