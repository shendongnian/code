    public static class AbstractAggregateFactory
    {
        public static AbstractAggregate<T> GetAggregateClient<T>() where T : ListItem
        {
            //use reflection to find the type that inherits AbstractAggregate<T>
            //instantiate the type
            //cast to AbstractAggregate<T> and return
        }
    }
    
    public class AskTankTruckAggregate : AbstractAggregate<AskItem>
    {
        //not implemented yet
    }
    
    public class TankTruckBlogAggregate : AbstractAggregate<BlogItem>
    {
        //not implemented yet
    }
    
    public class ResourcesAggregate : AbstractAggregate<ResourceItem>
    {
        //not implemented yet
    }
