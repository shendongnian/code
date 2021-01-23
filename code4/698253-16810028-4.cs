    public static class Here
    {
    	public static string Spot(HereOptions options)
    	{
    		return MakeMessageInternals(options, 3);
    	}
    
    	public static string Type
    	{
    		get
    		{
    			return MakeMessageInternals(HereOptions.Type, 3);
    		}
    	}
    
    	public static string Member
    	{
    		get
    		{
    			return MakeMessageInternals(HereOptions.Member, 3);
    		}
    	}
    
    	public static string FileLine
    	{
    		get
    		{
    			return MakeMessageInternals(HereOptions.FileLine, 3);
    		}
    	}
    
    	public static string FileName
    	{
    		get
    		{
    			return MakeMessageInternals(HereOptions.FileName, 3);
    		}
    	}
    
    	static StackFrame GetCaller(int index) { return new StackTrace(true).GetFrame(index); }
    
    	static string MakeMessageInternals(HereOptions options, int index)
    	{
    		StackFrame first = null;
    		var _FileName = new StringBuilder();
    		var _FileLine = new StringBuilder();
    		var _Member = new StringBuilder();
    		var _Type = new StringBuilder();
    
    		if ((options & HereOptions.FileName) == HereOptions.FileName)
    		{
    			first = GetCaller(index);
    			if (first != null)
    			{
    				var fn = first.GetFileName();
    				if (!string.IsNullOrEmpty(fn))
    					_FileName.Append(" " + Path.GetFileName(fn));
    			}
    		}
    
    		if ((options & HereOptions.FileLine) == HereOptions.FileLine)
    		{
    			if (first == null)
    				first = GetCaller(index);
    			if (first != null)
    			{
    				var ln = first.GetFileLineNumber();
    				_FileLine.Append(" #" + ln);
    			}
    		}
    
    		if ((options & HereOptions.Member) == HereOptions.Member)
    		{
    			if (first == null)
    				first = GetCaller(index);
    			if (first != null)
    			{
    				var mn = first.GetMethod().Name;
    				_Member.Append(" " + mn);
    			}
    		}
    
    		if ((options & HereOptions.Type) == HereOptions.Type)
    		{
    			if (first == null)
    				first = GetCaller(index);
    			if (first != null)
    			{
    				var dt = first.GetMethod().DeclaringType;
    				_Type.Append(string.Format(" ({0})", dt));
    			}
    		}
    
    		var messageInternal = string.Format("{0}{1}{2}{3}",
    			_FileName,
    			_FileLine,
    			_Member,
    			_Type).Trim();
    
    		return messageInternal;
    	}
    }
    
    [Flags]
    public enum HereOptions : byte
    {
    	None = 0,
    	FileName = 1,
    	FileLine = 2,
    	Member = 4,
    	Type = 8,
    	All = 15
    }
