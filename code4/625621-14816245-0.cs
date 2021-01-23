    public class MyServiceWrapper
    {
        public event EventHandler<string> CallCompleted;
        public string SendData()
        {
            return StaticService.SendData();
        }
        public void SendDataAsync()
        {
            ThreadPool.QueueUserWorkItem(new Action(()=>{
                var result = StaticService.SendData();
                var handler = CallCompleted();
                if (handler != null)
                {
                    handler(result);
                }
            }));
        }
    }
