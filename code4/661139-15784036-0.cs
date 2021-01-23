    Your are try to access Master Page Control so You Have to Try this 
    
    DropDownList d1 = (DropDownList)Master.FindControl("DropDownList1");
            DropDownList d2 = (DropDownList)Master.FindControl("DropDownList2");
            DropDownList d3 = (DropDownList)Master.FindControl("DropDownList3");
            SqlCommand scmd = new SqlCommand("select * from dreg where dcity='" + d2.SelectedItem.Text.ToString() + "' && dbg='" + d3.SelectedItem.Text.ToString() + "'", scon);
    
    
    as your accessing master Page Control so cann't use page.PreviousPage Instead of You have to 
    use Master.FindControl to access Master Page Control.
