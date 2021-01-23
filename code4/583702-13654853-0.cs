    public interface IEntity { }
    public class User : IEntity { }
    public class Experiments<T> where T : IEntity
    {
        private IList<T> list;
        private IList<Action<T>> actions;
        public Experiments()
        {
            list = new List<T>();
            actions = new List<Action<T>>();
        }
        public void Add(T entity)
        {
            list.Add(entity);
        }
        public void AddAction(Action<T> handle)
        {
            actions.Add(handle);
        }
    }
