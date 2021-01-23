    public interface IPacket
    {
    	String Data { get;set; }
        IList<IPacket> InnerPackets {get;set;}
    }
    
    public class Packet : IPacket
    {
    	public String Data { get;set; }
    	public IList<IPacket> InnerPackets {get;set;}
    }
