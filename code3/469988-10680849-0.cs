    // viewmodel code
      private void Login()
      {
           LoginContoller.Instance.Login(userName, password, ErrorCallbackCompleted);
      }
     //callback
     public void ErrorCallbackCompleted(Exception exception)
     {
     }
    // code inside singleton class
      public static Action<Exception> ErrorCallbackResponse;
    public void Login (string userName, string password, Action<Exception> errorCallback)
    {
       ErrorCallbackResponse = errorCallback;
    }
    public void GetErrorCallBack(Exception ex) // This method will be invoked from the error callback of web request class
    {
        ErrorCallbackResponse(ex);
    }
