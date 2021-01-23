    class RoomObject : ICloneable
    {
        public abstract object Clone();
    }
    
    class Bed : ICloneable
    {
        public override object Clone()
    	{
    	    return new Bed();
    	}
    }
    
    class Table : ICloneable
    {
        public override object Clone()
    	{
    	    return new Table();
    	}
    }
    
    class Program
    {
        public static void Main(String[] args)
    	{
    	    RoomObject ro = /* from some other places*/
    	    RoomObject newOne = ro.Clone() as RoomObject;  /* here's what you what */
    	}
    }
