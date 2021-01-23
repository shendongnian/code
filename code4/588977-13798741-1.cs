                int i=0;
                foreach(GridViewRow row in GridView1.Rows)
                {
                     Label xyz = (Label)row.FindControl("Label"+i);
                     Session["TaskID"+i] =xyz.Text; //to have unique session variables
                     i++;
                }
                Response.Redirect("~/tasks_edit.aspx"); // you should redirect only when you come out of the loop
