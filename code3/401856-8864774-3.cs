    #region Form Load
    private void frmMain_Load(object sender, EventArgs e)
    {
        try
        {
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();
            // Set the main form invisible so that only the splash form shows
            this.Visible = false;
            SetFormHeading();
            
            // Perform all long running work here. Loading of grids, checks etc.
            BindSalesPerson();
            BindCustomer();
            BindBrand();
            
            // Set the main form visible again
            this.Visible = true;
        }
        catch (Exception ex)
        {
            // Do some exception handling here
        }
        finally
        {
            // After all is done, close your splash. Put it here, so that if your code throws an exception, the finally will close the splash form
            CloseSplash();
        }
            
    } 
    #endregion
