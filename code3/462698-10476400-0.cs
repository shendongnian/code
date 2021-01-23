    abstract class Helper
    {
        public abstract IEnumerable<Entity> CreateList(IEnumerable<Entity> loadedList);
    }
    sealed class Helper<T> : Helper where T : Entity
    {
        public override IEnumerable<Entity> CreateList(IEnumerable<Entity> loadedList)
        {
            return new List<T> (loadedList.OfType<T> ());
        }
    }
