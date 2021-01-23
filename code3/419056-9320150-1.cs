    public class MyGameComponent : GameComponent, ICloneable
    {
    	public MyGameComponent(Game game) : base(game) { }
    	public MyGameComponentData MyGameComponentData { get; set; }
    	
    	public object Clone()
    	{
    		var clone = (MyGameComponent)MemberwiseClone();
    		
    		var formatter = new BinaryFormatter();
    		using (var stream = new MemoryStream())
    		{
    			formatter.Serialize(stream, this.MyGameComponentData);
    			stream.Seek(0, SeekOrigin.Begin);
    			clone.MyGameComponentData = 
                            (MyGameComponentData)formatter.Deserialize(stream);
    		}
    		
    		return clone;
    	}
    }
    
    [Serializable]
    public class MyGameComponentData
    {
    	public string Data1 { get; set; }
    	public List<string> Data2 { get; set; }
    }
