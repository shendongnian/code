    internal abstract class Base
    {
        public DateTime Time;
        public string Message;
        public string Log;
        public virtual void Invoke(string message) {
            Time = DateTime.Now;
        }
    }
    
    internal class SubA : Base
    {
    }
    
    internal class SubB : Base
    {
    }
