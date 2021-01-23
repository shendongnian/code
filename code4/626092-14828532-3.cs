    public class A
    {
        public void Some<T>() where T : ITask, new()
        {
             T instanceOfITask = new T();
        }
    }
