    public class SmartTable : DataTable
    {
    	//dummy/hard-coded values here for demonstration purposes
        public DataValue this[int Row, int Column]  { get { return new DataValue() {Value="3"}; } set { } }
        public DataValue this[int Row, string Column]  { get { return new DataValue() {Value="3"}; } set { } }
    }
    
    public class DataValue
    {
    	public string Value;
    	
    	public static implicit operator int(DataValue datavalue)
    	{
    		return Int32.Parse(datavalue.Value);
    	}
    	
    	public static implicit operator string(DataValue datavalue)
    	{
    		return datavalue.Value;
    	}
    }
