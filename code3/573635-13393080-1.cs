    public virtual void SubmitChanges()
    {
        if (DataContext != null)
        {               
            try
            {
                 DataContext.SubmitChanges();
            }
            catch (Exception whenILostMyConnection)
            {
                 SubmitChanges(); //recall the sumbitChanges
            }
        }             
    }
