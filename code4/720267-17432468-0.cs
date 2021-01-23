    try
    {
       //Some code here.
       //Also, set your breakpoints here.         
    }
    catch (InvalidOperationException exc)
    {
       MessageBox.Show(exc.ToString());
    }
    catch (Exception exception)
    {
       MessageBox.Show(exception.Message);
    }
