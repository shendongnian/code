    public enum AggregateTypes { TankTruckBlog, AskTankTruck, Resources }
    
    public static class AbstractAggregateFactory
    {
        public static AbstractAggregate GetAggregateClient(AggregateTypes type)
        {
            switch (type)
            {
                case AggregateTypes.AskTankTruck:
                    return new AskTankTruckAggregate<AskItem>();
                case AggregateTypes.TankTruckBlog:
                    return new TankTruckBlogAggregate<BlogItem>();
                case AggregateTypes.Resources:
                    return new ResourcesAggregate<ResourceItem>();
                default:
                    throw new AggregateDoesNotExistException();
            }
        }
    }
    
    public abstract class AbstractAggregate
    {
    }
    
    public abstract class AbstractAggregate<T> : AbstractAggregate
    {
    }
    //or change the definition to AskTankTruckAggregate : AbstractAggregate<AskItem>
    public class AskTankTruckAggregate<T> : AbstractAggregate<T>
    {
        //not implemented yet
    }
    
    //or change the definition to TankTruckBlogAggregate : AbstractAggregate<BlogItem>
    public class TankTruckBlogAggregate<T> : AbstractAggregate<T>
    {
        //not implemented yet
    }
    
    //or change the definition to ResourcesAggregate : AbstractAggregate<ResourceItem>
    public class ResourcesAggregate<T> : AbstractAggregate<T>
    {
        //not implemented yet
    }
