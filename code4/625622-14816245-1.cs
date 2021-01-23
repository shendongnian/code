    public class CompletedEventArgs : EventArgs
    {
        public string Result { get; set; }
    }
    public class MyServiceWrapper
    {
        public event EventHandler<CompletedEventArgs> CallCompleted;
        public string SendData()
        {
            return StaticService.SendData();
        }
        public void SendDataAsync()
        {
            ThreadPool.QueueUserWorkItem(state => {
                var result = StaticService.SendData();
                var handler = CallCompleted;
                if (handler != null)
                {
                    handler(this, new CompletedEventArgs{ Result = result });
                }
            });
        }
    }
