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
                        while (true)
                        {
                            try
                            {
                                var data = Encoding.UTF8.GetBytes("data: " + DateTime.Now.ToString() + "\n\n");
                                stream.Write(data, 0, data.Length);
                                stream.Flush();
                            }
                            catch (HttpListenerException e)
                            {
                                Console.WriteLine("Client browser disconnedted " + e.NativeErrorCode);
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                    }
                };
            };
        }
    }
