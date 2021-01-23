    public void something_resize(object sender, EventArgs e)
    {
        try
        {
            this.SuspendLayout(); 
            
            // Do your update, add data, redraw, w/e. 
            // Also add to ListViews and Boxes etc in Batches if you can, not item by item.  
        }
        catch
        {
        }
        finally
        {
            this.ResumeLayout(); 
        }
    } 
