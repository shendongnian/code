    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    ........
    try
    {
       ......
       // Remove the event handler, do your selection, No event on the listbox2 will be fired....
       listBox2.SelectedIndexChanged -= new System.EventHandler(this.listBox2_SelectedIndexChanged);
       // Do not remove the items , instead clear previous selection
       listBox2.ClearSelected(); 
       
       while (rdr.Read()) 
       { 
           int index = listBox2.FindString(rdr.GetString(0), -1);
           if(index != -1) listBox2.SetSelected(index, true)); 
       } 
       ....
    }
    finally
    {
        // before exit, reapply the event handler 
        listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
    }
    }
