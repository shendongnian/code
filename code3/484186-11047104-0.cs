    var myService = new new ServiceClient("httpBinding");
    try
    {
        myService.SomeMethod();
    }
    catch
    {
        // in case of exception, always call Abort*(
        myService.Abort();
        // handle the exception
        MessageBox.Show("error.....");
    }
    finally
    {
        myService.Close();
    }
