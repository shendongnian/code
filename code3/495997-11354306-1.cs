    public class Class2
    {
        public void UpdateMethod(Class1 instance)
        {
            if (VisualStyleElement.TaskbarClock.Time.GetTime() == SomeTime)
            {
                // here I want to change the state of instance1
                instance.SomeProperty = "Some Value";
            }
        }
    }
