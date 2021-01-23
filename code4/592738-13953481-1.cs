    using System;
    using System.Net;
    
    
    namespace HttpListenerTEst
    {
        class Program
        {
            private static HttpListener _listener;
    
            static void Main(string[] args)
            {
                _listener = new HttpListener();
                _listener.Prefixes.Add("http://localhost:60024/");
                _listener.Start();
                _listener.BeginGetContext(new AsyncCallback(Program.ProcessRequest), null);
    
                Console.ReadLine();
            }
    
            static void ProcessRequest(IAsyncResult result)
            {
                HttpListenerContext context = _listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                
                //Answer poll/get post data/do whatever
    
                _listener.BeginGetContext(new AsyncCallback(Program.ProcessRequest), null);
            }
        }
    }
