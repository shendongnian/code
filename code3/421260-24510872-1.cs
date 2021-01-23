    [Binding]
    public class TestRunSetup {
	
 
	// this method needs to be static
	[BeforeTestRun]
	public static void BeforeTestRun() 
        {
            if (RunApiTests()) <-- implement this method to choose whether to run the tests via your chosen method 
            {
	        Assembly.Load("Tests.API");
            }
            else 
            {
	        Assembly.Load("Tests.UI");
            }
        }
    }
