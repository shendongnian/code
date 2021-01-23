    public abstract class ListItem //or interface
    {
        protected abstract object Create();
    } 
    public class AskItem : ListItem { //implement to return AskTankTruckAggregate 
    }
    public class BlogItem : ListItem { //implement to return TankTruckBlogAggregate 
    }
    public class ResourceItem : ListItem { //implement to return ResourcesAggregate 
    }
    public static class AbstractAggregateFactory
    {
        public static AbstractAggregate<T> GetAggregateClient<T>() where T : ListItem, new()
        {
            return (AbstractAggregate<T>)new T().Create();
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
