    public abstract class ListItem<T> where T : ListItem<T> //or interface
    {
        protected abstract AbstractAggregate<T> Create();
    } 
    public class AskItem : ListItem<AskItem> { //implement to return AskTankTruckAggregate 
    }
    public class BlogItem : ListItem<BlogItem> { //implement to return TankTruckBlogAggregate 
    }
    public class ResourceItem : ListItem<ResourceItem> { //implement to return ResourcesAggregate 
    }
    public static class AbstractAggregateFactory
    {
        public static AbstractAggregate<T> GetAggregateClient<T>() where T : ListItem, new()
        {
            return new T().Create();
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
