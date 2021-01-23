    public class Class1
        {
            private void btn_click(object sender, EventArgs e)
            {
                ServerRequest sr = new ServerRequest();
                var callback = new ServerRequest.CallBackFunction(CallbackFunc);
                sr.DoRequest("myrequest",callback);
            }
    
            void CallbackFunc(string something)
            {
    
            }
    
    
        }
