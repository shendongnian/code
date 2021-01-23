	public abstract class CmdBody
	{
		public abstract byte[] ToBytes();
		
		protected abstract byte[] ToBytes();
		
		public abstract int GetLength();
	}
	public class CmdBodyA : CmdBody
	{
		public override byte[] ToBytes() 
		{ // Implementation }
	}
	public class CmdBodyB : CmdBody
	{
		public override byte[] ToBytes() 
		{ // Implementation }
	}
	
	public class Cmd<T> where T : CmdBody
	{ 
		public CmdHeader Header { get; set; }
		public T Body { get; set; }
		public byte[] ToBytes()
		{
			byte[] cmdBytes = new byte[Header.GetLength() + Body.GetLength()];
			Header.ToBytes().CopyTo(cmdBytes, 0);
			Body.ToBytes().CopyTo(cmdBytes, Header.GetLength());
			return cmdBytes;
		} 
	}
