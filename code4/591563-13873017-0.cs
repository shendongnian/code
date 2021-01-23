    [System.AttributeUsage(AttributeTargets.Property)]
    class ExportOptionsAttribute : System.Attribute
    {
    	public string Header { get; set; }
    	public string FormatString { get; set; }
    	public bool Export { get; set; }
    	public int Order { get; set; }
    
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="header"></param>
    	public ExportOptionsAttribute(string header) : this (header, null, true)
    	{
    	
    	}
    
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="header"></param>
    	/// <param name="formatString"></param>
    	/// <param name="export"></param>
    	public ExportOptionsAttribute(string header, string formatString, bool export)
    	{
    		this.Header = header;
    		this.FormatString = formatString;
    		this.Export = export;
    		this.Order = 0;
    	}
    }
    
