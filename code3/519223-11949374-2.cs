    foreach (var filter in filters)
        if !filter.Filter(item) return false;
    return true;
<!---->
    public interface IFilter
    {
        bool Filter(CommDGDataSource item);
    }
    public class ErrorFilter : IFilter
    {
        public bool Filter(CommDGDataSource item)
        {
            return item.Error;
        }
    }
    public class DestinationFilter : IFilter
    {
        public string Destination { get; set; }
        public bool Filter(CommDGDataSource item)
        {
            return item.Destination == Destination;
        }
    }
    //etc..
