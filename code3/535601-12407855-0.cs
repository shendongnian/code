    public class CsvParserProxy<CsvObjectType, ResultObjectType> : IParser<ResultObjectType> where CsvObjectType : new(), ResultObjectType, ICsvObject where ResultObjectType : new()
    {
    	private object _lock;
    	private CsvParser<CsvObjectType> _CsvParserInstance;
    	public CsvParser<CsvObjectType> CsvParserInstance {
    		get {
    			if (this._CsvParserInstance == null) {
    				lock ((this._lock)) {
    					if (this._CsvParserInstance == null) {
    						this._CsvParserInstance = new CsvParser<CsvObjectType>();
    					}
    				}
    			}
    
    			return _CsvParserInstance;
    		}
    	}
    
    	public IList<ResultObjectType> ReadFile(string path)
    	{
    		return this.Convert(this.CsvParserInstance.ReadFile(path));
    	}
    
    	public IList<ResultObjectType> ReadStream(System.IO.Stream sSource)
    	{
    		return this.Convert(this.CsvParserInstance.ReadStream(sSource));
    	}
    
    	public IList<ResultObjectType> ReadString(string source)
    	{
    		return this.Convert(this.CsvParserInstance.ReadString(source));
    	}
    
    	private List<ResultObjectType> Convert(IList<CsvObjectType> TempResult)
    	{
    		List<ResultObjectType> Result = new List<ResultObjectType>();
    		foreach (CsvObjectType item in TempResult) {
    			Result.Add(item);
    		}
    
    		return Result;
    	}
    }
