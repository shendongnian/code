    // the following three MsgId contracts don't have to be contracts at all (the actual types can be specified in generic IMsg directly), but if one ID type is wildly different in nature than the other, an interface such as this might make sense.
	public interface IMsgId
	{
	 // ?
	}
	
	public interface INewMsgId : IMsgId
	{
	}
	
	public interface ILegacyMsgId : IMsgId
	{
	}
	
	public interface IMsg<out TId>
	   where TId : IMsgId
	{
	   TId MessageId { get; }
	
	   byte[] MsgBytes { get; }
	}
	// if it is sensible, you can use the following interfaces to create definitive new and legacy message contracts
	public interface INewMsg : IMsg<INewMsgId>
	{
	}
	public interface ILegacyMsg : IMsg<ILegacyMsgId>
	{
	}
