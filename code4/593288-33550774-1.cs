    /* Showing the try-catch block only */
    try
    {
        using (TransactionScope tran = new TransactionScope())
        {
             UpdateMethod1();
             UpdateMethod2();
             UpdateMethod3();
             UpdateMethod4();
        
             if (bAllUpdated == true)
             {
                 tran.Complete();
                 lblSC_Success.Visible = true;
             }
             else
                 throw new TransactionAbortedException();
        }
    }
                    
    catch (TransactionAbortedException ex)
    {
          bAllUpdated = false;
          lblSCEditWarning.Text = "There was an error and your changes where NOT saved. " + ex.Message;
    }
    catch (ApplicationException ex)
    {
        bAllUpdated = false;
        lblSCEditWarning.Text = "There was an error and your changes where NOT saved. " + ex.Message;
    }
    catch (Exception ex)
    {
        bAllUpdated = false;
        lblSCEditWarning.Text = "There was an error and your changes where NOT saved. " + ex.Message;
    }
    finally
    {
        // Clean up the temp tables
        // Refresh page
    }
                  
      
