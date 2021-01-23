    public interface IHandler
    {
    	void InsertTool(ITool tool);
    	void UpdateTool(ITool tool);
        void DeleteTool(string toolID);
    	//void DeleteTool(ITool tool) - seems more consistent if possible!?
        ITool QueryTool(string toolID);
    }
    
    public interface ITool
    {
    	
    }
    
    class BallMill : ITool
    {
    }
    
    class DiamondTool : ITool
    {
    }
    
    class BallMillDBHandler : IHandler
    {
    
        public BallMillDBHandler(){ ... }
    
        public void InsertTool(ITool tool) { ... }
        public BallMill QueryTool(string toolID) { ... }
        public void UpdateTool(ITool tool) { ... }
        public void DeleteTool(string toolID) { ... }
    }
    
    class DiamondToolDBHandler : IHandler
    {
    
        public DiamondToolDBHandler(){ ... }
    
        public void InsertTool(ITool tool) { ... }
        public DiamondTool QueryTool(string toolID) { ... }
        public void UpdateTool(ITool tool) { ... }
        public void DeleteTool(string toolID) { ... }
    }
