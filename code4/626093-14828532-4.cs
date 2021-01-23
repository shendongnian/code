    // The abstract factory!
    public static class TaskFactory
    {
        public static T Create<T>() where T : ITask, new()
        {
             T instanceOfITask = new T();
             // more stuff like initializing default values for the newly-created specific task
    
             return instanceOfITask;
        }
    }
    
