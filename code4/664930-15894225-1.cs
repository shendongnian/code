    public class FilterInfo
    {
        public InputInfo[] inputs { get; internal set; } 
        public OutputInfo[] outputs { get; internal set; };
        bool IsConfigurable;
        bool IsPlayable;
        string TypeName;
    	
    	public void SetInputs(...)
    	{
    		InputInfo[] allInputs;
    		//do stuff
    		inputs = AllInput;
    	}
    	
    	public void SetOutputs(...)
    	{
    		OutputInfo[] allOutputs;
    		//do stuff
    		outputs = AllOutput;
    	}
    }
