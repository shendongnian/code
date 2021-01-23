    internal abstract class Base
    {
        ...
        public void Invoke(string message)
        {
            Time = DateTime.Now;
            this.InvokeCore(message);
        }
        protected abstract void InvokeCore(string message);
    }
    
    internal class SubA : Base
    {
        public override void Invoke(string message)
        {
            // Do A
        }
    }
    
    internal class SubB : Base
    {
        public override void InvokeCore(string message)
        {
            // Do B
        }
    }
