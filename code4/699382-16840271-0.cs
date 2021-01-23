    void Main()
    {
    	Func<int,int> dlgt = FuncHolder.SomeMethod;
    	var ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    	byte[] buffer;
    	using(var ms = new MemoryStream())
    	{
    		ser.Serialize(ms, dlgt);
    		buffer = ms.ToArray();
    	}
    	Console.WriteLine("{0} was serialized to {1} bytes", dlgt.GetType().Name, buffer.Length);
    	using(var ms = new MemoryStream(buffer))
    	{
    		dynamic whatzit = ser.Deserialize(ms);
    		whatzit(1);
    	}
    }
    
    [Serializable]
    public struct FuncHolder
    {
    	public static int SomeMethod(int i)
    	{
    		Console.WriteLine("I was called with {0}, returning {1}", i, i+1);
    		return i+1;
    	}
    }
