    public class Class1
        {
    
            private void btn_click(object sender, EventArgs e)
            {
                ServerRequest sr = new ServerRequest();
                sr.Callback += new ServerRequest.CallbackEventHandler(sr_Callback);
                sr.DoRequest("myrequest");
            }
    
            void sr_Callback(string something)
            {
                
            }
    
            
        }
    
        public class ServerRequest
        {
            public delegate void CallbackEventHandler(string something);
            public event CallbackEventHandler Callback;   
            
            public void DoRequest(string request)
            {
                // do stuff....
                if (Callback != null)
                    Callback("bla");
            }
        }
