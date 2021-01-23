    internal class TaskProcessor
    {
        // All of the work/logic goes in this class which can have instances
    }
    public static class StaticHelper
    {
        private TaskProcessor _processor = new TaskProcessor();
        public static void SomeMethod()
        {
            _processor.SomeMethod();
        }
 
        // And so on
    }
