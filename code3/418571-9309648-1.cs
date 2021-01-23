    internal abstract class Base
    {
        public DateTime Time;
        public string Message;
        public string Log;
        public abstract void Invoke(string message);
        public void SetTime()
        {
            Time = DateTime.Now; 
        }
    }
    internal class SubA : Base
    {
        public override void Invoke(string message)
        {
            SetTime();
            // Do A
        }
    }
    internal class SubB : Base
    {
        public override void Invoke(string message)
        {
            SetTime();
            // Do B
        }
    }
