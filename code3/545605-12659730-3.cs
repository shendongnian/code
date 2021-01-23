    try
    {
        using (var wcurs = new WaitingCursor())
        {
            MyProcessingTask();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
