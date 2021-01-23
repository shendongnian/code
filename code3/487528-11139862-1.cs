    try
    {
       ......
       // Remove the event handler, do your updatework
       // No event will be fired....
       listBox2.SelectedIndexChanged -= new System.EventHandler(this.listBox2_SelectedIndexChanged);
       listBox2.Items.Clear(); 
       while (rdr.Read()) 
       { 
           listBox2.Items.Add(rdr.GetString(0)); 
       } 
       ....
    }
    finally
    {
        // before exit, reapply the event handler 
        listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
    }
