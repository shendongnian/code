    [DataContract(Namespace = "a namespace",Name="Contacts")]
    public class Contacts
    {
    	private List<Contact> contacts= null;
    	[DataMember]
    	public List<Contact> Contacts
    	{
    		get
    		{
    			if (contacts == null)
    			{
    				contacts = new List<Contact>();
    			}
    			return contacts;
    		}
    		set
    		{
    			contacts= value;
    		}
    	}
    }
