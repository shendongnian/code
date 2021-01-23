                foreach(GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int i=0;
                        Label xyz = (Label)row.FindControl("Label"+i);
    
                        Session["TaskID"+i] =xyz.Text;
                        i++;
                     }
                }
                Response.Redirect("~/tasks_edit.aspx");
