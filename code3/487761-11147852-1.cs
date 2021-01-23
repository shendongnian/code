    public interface IPTask<T>
    {
        bool CanExecute(T instance);
        T Process(T instance);
    }
    internal interface IProcessor<T>
    {
        T Execute(T instance);
    }
    public interface ITasks<T>
    {
        IEnumerable<IPTask<T>> GetTasks();
    }
    public class Processor<T> : IProcessor<T>
    {
        private readonly ITasks<T> _tasks;
        public Processor(ITasks<T> tasks)
        {
            this._tasks = tasks;
        }
        public T Execute(T instance)
        {
            return this._tasks.GetTasks().Aggregate(instance, (current, task) => InternalExecute(task, current));
        }
        public T ExecuteWithPartial(T instance)
        {
            var target = instance;
            try
            {
                foreach (var task in this._tasks.GetTasks())
                {
                    target = InternalExecute(task, target);
                }
                return target;
            }
            catch (CantExecuteException)
            {
                return target;
            }
        }
        private static T InternalExecute(IPTask<T> task, T instance)
        {
            if (!task.CanExecute(instance))
                throw new CantExecuteException();
            return task.Process(instance);
        }
    }
    public class CantExecuteException : Exception
    {
    }
