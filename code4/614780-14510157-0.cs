    public class Program
    {
        static void Main(string[] args)
        {
            var ef = new EntityFilter<TestEntity>();
            DoSomething(ef);
        }
        public static void DoSomething(IEntityFilter<IEntity> someEntityFilter)
        {
        }
    }
    public interface IEntityFilter<out T>
    { }
    public class EntityFilter<T> : IEntityFilter<T>
    { }
    public interface IEntity
    { }
    public class TestEntity : IEntity
    { }
