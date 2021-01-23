    static async Task ProcessAsync(HttpListener listener) {
        while (KeepGoing) {
            var context = await listener.GetContextAsync();
            HandleRequestAsync(context);         
        }
    }
    static async Task HandleRequestAsync(HttpListenerContext context) {
        // Do processing here, possibly affecting KeepGoing to make the 
        // server shut down.
    }
