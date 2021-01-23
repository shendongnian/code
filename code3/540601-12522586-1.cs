    namespace Your.App
    {
    //correct implementation of the Strategy Pattern
        interface ICommunication
        {
            void Send();
        }
        class SyncCommunication : ICommunication
        {
            public void Send() { /*your sync code*/ }
        }
        class AsyncCommunication : ICommunication
        {
            public void Send() { /*your async code*/ }
        }
        public class WorkClass
        {
            ICommunication Strategy { get; set; }
            public WorkClass()
            {
                UseAsync = false;
            }
            bool _useAsync;
            public bool UseAsync 
            {
                get { return _useAsync; }
                set
                {
                    _useAsync = value;
                    if(_useAsync)
                        Strategy = new AsyncCommunication();
                    else
                        Strategy = new SyncCommunication ();
                }
            }
            public void Send()
            {
                Strategy.Send();
            }
        }
    }
