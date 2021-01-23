    public class Class2
    {
        private readonly Class1 instance;
        public Class2(Class1 instance)
        {
            this.instance = instance;
        }
        public void UpdateMethod()
        {
            if(VisualStyleElement.TaskbarClock.Time.GetTime() == SomeTime)
            {
                // here I want to change the state of instance1
                this.instance.SomeProperty = "Some Value";
            }
        }
    }
