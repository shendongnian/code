    var inList = true;
    foreach (var filter in filters)
        inList = filter.Filter(item) && inList;
    return inList;
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
