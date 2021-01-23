    public class ClockModule : NancyModule
    {
        public ClockModule()
        {
            Get["/clock"] = (args) => {
                return new Response
                {
                    ContentType = "text/event-stream",
                    Contents = (Stream stream) =>
                    {
                        var data = Encoding.UTF8.GetBytes("retry: 1000\ndata: " + DateTime.Now.ToString() + "\n\n");
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                    }
                };
            };
        }
    }
