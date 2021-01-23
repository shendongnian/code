    private void update(object sender, EventArgs e)
    {
        if (InvokeRequired)
        {
            EventHandler handler = new EventHandler(update);
            try 
            {
                Invoke(handler); 
            }
            catch (Exception) 
            {
                // Control disposed while invoking.  Nothing to do 
            }
            return;
        }
    
        label.Text = "blah";
    }
 
