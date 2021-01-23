        internal abstract class Base
        {
            public DateTime Time;
            public string Message;
            public string Log;
            public void Invoke(string message)
            {
                Time = DateTime.Now;
                this.InvokeDescendant(message);
            }
            protected abstract void InvokeDescendant(string message);
        }
        internal class SubA : Base
        {
            protected override void InvokeDescendant(string message)
            {
                // Do A
            }
        }
        internal class SubB : Base
        {
            protected override void InvokeDescendant(string message)
            {
                // Do B
            }
        }
