    if(e.Row.RowType == DataControlRowType.DataRow)
    {
                Textbox text1 = ((Textbox )e.Row.FindControl("Textbox1"));
                Textbox text2 = ((Textbox )e.Row.FindControl("Textbox2"));
                text2 .Attributes.Add("onfocus", "EventName('"+text1 .Text+"','"+text1.Text+"')"+);
               
    }
  }
