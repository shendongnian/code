    public static class AggregateHelper
    {
        public enum AggregateTypes { TankTruckBlog, AskTankTruck, Resources }
    }
    public class AskItem { }
    public class BlogItem { }
    public class ResourceItem { }
    public static class AbstractAggregateFactory
    {
        public static AbstractAggregate<T> GetAggregateClient<T>
           (AggregateHelper.AggregateTypes type)
        {
            switch (type)
            {
                case AggregateHelper.AggregateTypes.AskTankTruck:
                    return new AskTankTruckAggregate<T>();
                case AggregateHelper.AggregateTypes.TankTruckBlog:
                    return new TankTruckBlogAggregate<T>();
                case AggregateHelper.AggregateTypes.Resources:
                    return new ResourcesAggregate<T>();
                default:
                    throw new ArgumentException();
            }
        }
    }
    public abstract class AbstractAggregate<T>
    {
        public abstract List<T> GetAggregate(Guid[] resourcetypes);
        public abstract T GetSingle(string friendlyname);
    }
    public class AskTankTruckAggregate<T> : AbstractAggregate<T>
    {
        public override List<T> GetAggregate(Guid[] resourcetypes)
        {
            throw new NotImplementedException();
        }
        public override T GetSingle(string friendlyname)
        {
            Console.WriteLine(friendlyname);
            Type whats_t = typeof(T);
            return default(T);
        }
    }
    public class TankTruckBlogAggregate<T> : AbstractAggregate<T>
    {
        //not implemented yet
    }
    public class ResourcesAggregate<T> : AbstractAggregate<T>
    {
        //not implemented yet
    }
