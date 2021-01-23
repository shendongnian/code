    namespace So17022438CallbackHandlers
    {
        delegate void ApiCallback (Guid threadId, int param);
        class Program {
            class Handler {
                public string Name;
                public ApiCallback Callback;
                public Handler (string name)
                {
                    Name = name;
                    Callback = (id, param) => OnApiCallback(Name, param);
                }
            }
            static void Main (string[] args) {
                var apis = new[] { new Api(), new Api() };
                apis[0].RegisterCallback(new Handler("Name1").Callback);
                apis[1].RegisterCallback(new Handler("Name2").Callback);
                apis[0].CallCallback();
                apis[1].CallCallback();
                Console.ReadKey();
            }
            static void OnApiCallback (string name, int param) {
                Console.WriteLine(name + " - " + param);
            }
        }
        class Api {
            private ApiCallback _callback;
            public void RegisterCallback (ApiCallback callback) {
                _callback = callback;
            }
            public void CallCallback () {
                _callback(new Guid(), 1);
            }
        }
    }
