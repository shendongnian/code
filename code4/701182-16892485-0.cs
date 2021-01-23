    public interface IPacket
    {
    	String Data { get;set; }
    }
    
    public class Packet : IPacket
    {
    	public String Data { get;set; }
    	public IPacket InnerPacket {get;set;}
    }
