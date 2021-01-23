    public static class MemoryStreamExtensions
    {
    	public static void Write(this MemoryStream stream, params object[] parameters)
    	{
    		if (stream != null)
    		{
    			foreach (var obj in parameters)
    			{
    				if (obj is byte)
    				{
    					stream.WriteByte((byte)obj);
    				}
    				else if (obj is byte[])
    				{
    					var theArray = (byte[])obj;
    					stream.Write(theArray, 0, theArray.Length);
    				}
    			}
    		}
    	}
    }
    
    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		MemoryStream zz = new MemoryStream();
    		zz.Write((byte)1, (byte)4, new byte[] { 5, 6 });
    
    		Console.ReadKey();
    	}
    }
