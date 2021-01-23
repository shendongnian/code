    public abstract class Task
    {
        protected Task(Func<TaskList, IBuilder> builderStrategy)
        {
            _builderStrategy = builderStrategy;
        }
 
        public IBuilder GetBuilder(TaskList todoList))
        {
            return _builderStrategy(todolist);
        }
    }
    public class Note : Task
    {
        public Note(Func<TaskList, IBuilder> builderStrategy) : base(builderStrategy) {}
    }
    // ...
    note = new Note(x => return new noteBuilder(x));
    
