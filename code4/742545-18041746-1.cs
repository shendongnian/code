    public class MyStreamWriter:StreamWriter
    {
        public MyStreamWriter(Stream s):base(s)
    	{
    	}
    	
    	public override void Write(string s)
    	{
    		base.Write(s.Replace("\n",Environment.NewLine));
    	}	
    }
