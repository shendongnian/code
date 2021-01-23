    protectected void Gv_RowCommand(object sender, GridRowCommandEventArgs e)
    {
       if(e.CommandName.Equals("remove_member"))
       {
            string mem_id = e.CommandArgument.ToString();
            db.remove_member(mem_id, num);
           
       }
       System.Thread.Sleep(500); // To hold the current thread for few second to complete the operation and then redirect to your desired page
        Response.Redirect("memberInevents.aspx?enum=" + num);
    }
