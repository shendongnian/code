    using(var wcurs = new WaitingCursor())
    {
        try 
        {
            MyProcessingTask();
        }
        catch (Exception ex) 
        {
            MessageBox.Show(ex.ToString());
        }
    }
