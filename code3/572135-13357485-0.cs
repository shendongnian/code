    public interface INetwork
    {
        DateTime? Date { get; }
    }
    
    public partial class Networking :EntityBase, INetwork
    {
        public DateTime? Date
        {
            get { return NetWorkingDate; }
        }
    }
    
    public partial class PrivateNetwork :EntityBase, INetwork
    {
        public DateTime? Date
        {
            get { return DateCreation; }
        }
    }
    
    var commonList = new List<INetwork>();
    // Add instances of PrivateNetwork and Networking to the list
    
    var orderedByDate = commonList.OrderBy(n => n.Date);
