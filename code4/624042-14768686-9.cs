    foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
        if (cb != null && cb.Checked)
        {
            row.Visible = false;
            var firstname = (row.FindControl("labelFirstName") as Label).Text; //my guess that you are binding DataRows to labels in grid view? if not this has to be changed
            var lastname = (row.FindControl("labelLastName") as Label).Text; //same as above
    
            foreach (GridViewRow row in GridView2.Rows)
            {
                 var found = false;
                 // logic to search for row
                 if (found)
                 {
                      row.Visible = false;
                 }
            }
        }
        else
        {
            Response.Write("Select check box to Delete");
        }
    }
