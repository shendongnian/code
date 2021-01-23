    public class MyListenerThatDoesNotShowDialogOnFail: 
           System.Diagnostics.TraceListener
    {
        // This is to avoid message box on Debug.Assert(false);
        public override void Fail(string message, string detailMessage)
        {// do something UnitTest friendly here like Assert.Fail(false)
        }
    
        // This (+Write) is to redirect Debug.WriteLine("Some trace text");
        public override void WriteLine(string message)
        {// do something UnitTest friendly here like TestContext.Write(message)
        }
    }
