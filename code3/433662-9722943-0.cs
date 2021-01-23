    public interface IBaseFunctions
    {
        IUser GetCurrentUser();
    
        void ShowMessage(String message);
    }    
    public class BaseFunctionsHelper : IBaseFunctions
    {
        public IUser GetCurrentUser()
        {
            // Get Current User
        }
        public void ShowMessage(String message)
        {
            // Show message
        }
    }
    public class BaseForm : Form, IBaseFunctions
    {
        private readonly IBaseFunctions _helper = new BaseFunctionsHelper();
        public IUser GetCurrentUser()
        {
            return _helper.GetCurrentUser();
        }
        public void ShowMessage(String message)
        {
            return _helper.ShowMessage(message);
        }
    }
    public class BaseControl : UserControl, IBaseFunctions
    {
        private readonly IBaseFunctions _helper = new BaseFunctionsHelper();
        public IUser GetCurrentUser()
        {
            return _helper.GetCurrentUser();
        }
        public void ShowMessage(String message)
        {
            return _helper.ShowMessage(message);
        }
    }
