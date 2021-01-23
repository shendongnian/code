    public class MyApp : System.Windows.Application
    {
    }
    if (System.Windows.Application.Current == null)
    {
        // create the Application object
        new MyApp();
    }
The above code is not exercised by the unit test in question. However, *it was being exercised in other unit tests that were being run beforehand*, and all were run together using the /noisolation flag with MSTest.exe.
