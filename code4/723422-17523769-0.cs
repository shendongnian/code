    public class ClassUnderTest
    {
        public IMessageBoxService MessageBoxService { get; set; }
    
        public void SomeMethod()
        {
            //Some logic
    
            MessageBoxService.Show("message");
    
            //Some more logic
        }
    }
    
    interface IMessageBoxService
    {
        void Show(string message);
    }
    
    public class MessageBoxService : IMessageBoxService
    {
        public void Show(string message)
        {
            MessageBox.Show("");
        }
    }
