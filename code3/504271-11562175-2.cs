    void Main()
    {
    	List<VariableData> outputVariableData = 
    	new List<VariableData>();
    
    	for(int i = 1 ; i< 100; i ++)
    	{
    	outputVariableData.Add(new VariableData
    		{ 
    		Id = i,
    		VariableValue = .33     
    		});
    	}
    
    	double result = outputVariableData.Average(dd=> dd.VariableValue);
    	double add = outputVariableData.Sum(dd=> dd.VariableValue)/99;
    	add.Dump();
    	add.ToString("P0").Dump();
    	add.ToString("N2").Dump();
    	result.Dump();
    	result.ToString("P0").Dump();
    	result.ToString("N2").Dump();
    }
    
    public class VariableData
    {
    		public int Id { get; set; } 
    		public double VariableValue{ get; set; }
    }
