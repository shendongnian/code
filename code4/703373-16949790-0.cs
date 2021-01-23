    public class XListener
    {
        HttpListener listener;
    
        public XListener(string prefix)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
        }
    
        public void StartListen()
        {
            if (!listener.IsListening)
            {
                listener.Start();
                Task.Factory.StartNew(async () =>
                {
                    while (true) await Listen(listener);
                }, TaskCreationOptions.LongRunning);
                Console.WriteLine("Listener started");
            }
        }
    
        public void StopListen()
        {
            listener.Stop();
            Console.WriteLine("Listener stopped");
        }
    
        private async Task Listen(HttpListener l)
        {
            try
            {
                var ctx = await l.GetContextAsync();
    
                var text = "Hello World";
                var buffer = Encoding.UTF8.GetBytes(text);
    
                using (var response = ctx.Response)
                {
                    ctx.Response.ContentLength64 = buffer.Length;
                    ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (HttpListenerException)
            {
                Console.WriteLine("screw you guys, I'm going home!");
            }
        }
    }
