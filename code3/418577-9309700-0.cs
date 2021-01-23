    internal abstract class Base
    {
        public DateTime Time;
        public string Message;
        public string Log;
        public virtual void Invoke(string message)
        {
            Time = DateTime.Now;
        }
    
    }
    
    internal class SubA : Base
    {
        public override void Invoke(string message)
        { 
            base.Invoke(message);
            // Do A
        }
    }
    
    internal class SubB : Base
    {
        public override void Invoke(string message)
        {
            base.Invoke(message);
            // Do B
        }
    }
