    class DBHandler<TTool> // where TTool : ToolBase
    {
        public DBHandler(){ ... }
    
        public void InsertTool(TTool tool) { ... }
        public TTool QueryTool(string toolID) { ... }
        public void UpdateTool(TTool tool) { ... }
        public void DeleteTool(string toolID) { ... }
    }
