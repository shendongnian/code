    Get["/clock"] = (args) => {
        return new Response
        {
            ContentType = "text/event-stream",
            Contents = (Stream stream) =>
            {
                try
                {
                    var data = Encoding.UTF8.GetBytes("retry: 1000\ndata: " + DateTime.Now.ToString() + "\n\n");
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
                catch (HttpListenerException e)
                {
                    Console.WriteLine("Client browser disconnedted " + e.NativeErrorCode);
                }
            }
        };
    };
