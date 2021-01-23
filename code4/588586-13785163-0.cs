    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event myEvent = new Event();
            GridViewRow row = GridView1.SelectedRow;
            myEvent.EventID = Convert.ToInt32(row.Cells[1].Text);
            myEvent.Sport = row.Cells[2].Text;
            myEvent.EventName = row.Cells[3].Text;
            myEvent.Section = Convert.ToInt32(row.Cells[4].Text);
            myEvent.TicketsAvailable = Convert.ToInt32(row.Cells[5].Text);
            myEvent.EventDate = Convert.ToDateTime(row.Cells[6].Text);
            Session["myEvent"] = myEvent;
    
            Response.Redirect("Complete.aspx");
        }
