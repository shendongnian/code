    [TestClass]
    public class Page : PageContract, IWindowControlAccess
    {
	[AssemblyCleanup()]
        public static void ApplicationCleanup()
        {
            Cleanup();
        }
    }
