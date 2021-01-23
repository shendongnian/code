    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               //Presume that the buttonField is at 1st cell
                LinkButton link = e.Row.Cells[0].Controls[0] as LinkButton;
    
                if (link != null)
                {
                    link.Attributes.Add("onclick", "alert('Hello');");
                }
            }
        }
