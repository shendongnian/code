	public class LegacyMsgId : ILegacyMsgId
	{
	    public LegacyMsgId(int id)
		{
		  Id = id;
		}
	    
		public int Id { get; private set; }
		
		
	   	public override string ToString()
		{
			return "Legacy Message #" + Id;
		}
	}
	
	public class NewMsgId : INewMsgId
	{
	    public NewMsgId(int id)
		{
			Id = id;
		}
		
	    public int Id { get; private set; }
		
		public override string ToString()
		{
			return "New Message #" + Id;
		}
	}
	
	public class NewMsg : INewMsg
	{
	    public NewMsg(int id)
		{
			MessageId = new NewMsgId(id);
		}
		
	    public NewMsgId MessageId { get; private set; }
		
	    INewMsgId IMsg<INewMsgId>.MessageId { get { return MessageId; } }
		
		public byte[] MsgBytes { get; private set; }
	}
	
	public class LegacyMsg : ILegacyMsg
	{
	    public LegacyMsg(int id)
		{
			MessageId = new LegacyMsgId(id);
		}
	
	    public LegacyMsgId MessageId { get; private set; }
		
	    ILegacyMsgId IMsg<ILegacyMsgId>.MessageId { get { return MessageId; } }
		
		public byte[] MsgBytes { get; private set; }
	}
