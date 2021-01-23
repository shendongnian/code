    public class Class1
    {
        public void DoSomething(Action<string> onSuccess, Action<Exception> onError)
        {
            try
            {
                // Logic to really do something...
    
                if (onSuccess != null)
                    onSuccess("updated value");
            }
            catch (Exception ex)
            {
                if (onError != null)
                    onError(ex);
            }
        }
    }
