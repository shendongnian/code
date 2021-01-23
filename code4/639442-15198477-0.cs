    public class MyBootstrapper
    {
        [Import]
        XLHandler XLHandler;
    
        //Automatically called by ExcelDna library, I do not instantiate this class
        public void AutoOpen()
        {
            //Leave your implementation unchanged.
        }
    }
