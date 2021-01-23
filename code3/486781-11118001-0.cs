    public class MyOwnForm : Form 
    {
        private override OnLoad(...)
        {
            base.OnLoad(..);
            
            AcceptButton = yourOkButtonObject;
        }
    }
