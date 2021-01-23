     public class Base
      {
        public DateTime Time;
        public string Message;
        public string Log;
        public Action<string> Invoke { get; set; }
            
        public Base()
        {
           this.Invoke = InvokeDefault;
        }
        
        private void InvokeDefault(string message)
        {
           Time = DateTime.Now;
        }
      }
