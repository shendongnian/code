    internal abstract class Base
    {
        public DateTime Time;
        public string Message;
        public string Log;
        public abstract void Invoke(string message);
    
    
        public virtual void Invoke(string message)
        {
            Time = DateTime.Now;        
        }
    }
