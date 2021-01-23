    foreach (RepeaterItem item in Repeater1.Items)
    {
    TextBox Subject_Id= (TextBox)item.FindControl("Subject_Id");
    TextBox Subject_Name= (TextBox)item.FindControl("Subject_Name");
    TextBox Marks= (TextBox)item.FindControl("Marks");
    // call SQL function to update the above values to database
    
    }
