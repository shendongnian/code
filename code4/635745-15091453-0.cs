    foreach (GridViewRow gvr in table_example.Rows)
            {
                if (((CheckBox)gvr.FindControl("CheckBox1")).Checked == true)
                {
                    //Here I need the tID of the row that is checked
    
    int tID = Convert.ToInt32(gvr.Cells[1].Text);
                    WebService1 ws = new WebService1();
                    ws.addID(tID);
                }
            }
