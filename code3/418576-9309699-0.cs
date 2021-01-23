    internal abstract class Base
    {
        public DateTime Time;
        public string Message;
        public string Log;
        public void Invoke(string message){
             Time = DateTime.Now;
             this.InvokeInternal(message);
        }
        protected abstract void InvokeInternal(string message);
    }
    
    internal class SubA : Base
    {
        protected override void InvokeInternal(string message)
        {
            // Do A
        }
    }
    
    internal class SubB : Base
    {
        protected override void InvokeInternal(string message)
        {
            // Do B
        }
    }
