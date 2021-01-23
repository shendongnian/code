    for (int i = 0; i < GridView2.Rows.Count; i++)
    {
      //extract the TextBox values
      Label lblname= (Label)GridView2.Rows[i].Cells[0].FindControl("lblname");
      Label lblPickUpPoint= (Label)GridView2.Rows[i].Cells[0].FindControl("lblPickUpPoint");
      //Do your excel binding here
    }
