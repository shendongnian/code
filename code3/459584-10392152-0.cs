    [XmlRoot("TransactionCollection")]
    public class TransactionCollection
    {
    	private List<List<Transaction>> _lst = new List<List<Transaction>>();	
    
    	[XmlArrayItemAttribute()]
    	public List<List<Transaction>> Transactions { get { return _lst; } }
    
    	public TransactionCollection()
    	{
    	}
    }
    
    [XmlRoot("Transaction")]
    public class Transaction
    {
    	[XmlElement("Id")]
    	public string Id = String.Empty;
    }
