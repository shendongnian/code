    void ShowServerTime_ButtonClick()
    {
        MyServiceHandler.GetServerTime(result => {
            // do something with "result" here
        });
    }
    public class MyServiceHandler
    {
        // wire up the handler in the constructor
        static MyServiceHandler()
        {
            WCFService.GetServerTimeCompleted += (sender, args) 
            {
                // assume you're going to pass the callback delegate in the User State:
                var handler = args.UserState as Action<string>;
                if (handler != null) handler(args.Result);
            }
        }
        public static string GetServerTime(Action<string> callback)
        {
            // send the callback so that the async handler knows what to do:
            WCFService.GetServerTimeAsync(callback)
        }
    }
