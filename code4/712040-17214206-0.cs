    [DataContract]
    internal sealed class SerializableSessionStateStoreData
    {
    	[DataMember(Name = "Keys")]
    	private string[] _keys;
    	[DataMember(Name = "Values")]
    	private object[] _values;
    	[DataMember(Name = "Timeout")]
    	private int _timeout;
    	[DataMember(Name = "SessionStateActions")]
    	private SessionStateActions _sessionStateActions;
    	public SerializableSessionStateStoreData(SessionStateStoreData storeData, SessionStateActions sessionStateActions)
    	{
    		...
    	}
    	public Tuple<SessionStateStoreData, SessionStateActions> Restore()
    	{
    		...
    	}
    }
