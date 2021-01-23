    void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
    foreach (GridViewRow gRow in GridView1.Rows)
    {
    TextBox myfieldtxt = gRow.FindControl("yourTxtBxID") as TextBox;
    Label myLable = gRow.FindControl("yourLableID") as Label;
            
    if(myLable.Text.Equals("XYZ"))
    {
      myfieldtxt.TextMode = TextBoxMode.MultiLine;
    }
    else
    {
     myfieldtxt.TextMode = TextBoxMode.Single;
    }
    }
    }
