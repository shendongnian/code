    [StructLayout(LayoutKind.Explicit)]
    public struct Evil
    {
    	[FieldOffset(0)]
    	public string s;
    
    	[FieldOffset(0)]
    	public object o;
    }
    string ReinterpretCastToString(object o)
    {
        Evil evil=new Evil();
        evil.o=o;
		return evil.s;
    }
    void Main()
    {
        string s = ReinterpretCastToString(1);
    
        if (s.GetType() == typeof(int))
        {
            Console.WriteLine("This should not happen!"); 
        }
    }
