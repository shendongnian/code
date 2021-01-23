    public class A<T> where T : ITask, new()
    {
        public void Some() 
        {
             T instanceOfITask = new T();
        }
    }
