    try
    {
        //Your code goes here
    }
    catch (Win32Exception e)
    {
        //Handle the exception here, or use one of the following to find out what the issue is:
        Console.WriteLine(e.Message);
        MessageBox.Show(e.Message, "Exception");
    }
