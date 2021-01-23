    class Program
    {
    	static void Main()
    	{
    	 Dictionary<string, Action> dict = new Dictionary<string, Action>();
    	 dict["loadFile"] = new Action(LoadFile);
    	 dict["saveFile"] = new Action(SaveFile);
    
    	 dict["loadFile"].Invoke();
    	 dict["saveFile"].Invoke();
    	}
    
    	static void SaveFile()
    	{
         Console.WriteLine("File saved!");
    	}
    
    	static void LoadFile()
    	{
    	 Console.WriteLine("Loading File...");
    	}
    }
