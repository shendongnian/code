    class Robot {
        private ITool currentTool = null;
        public void Pickup(ITool tool)
        {
            currentTool = tool;
        }
        public void UseTool() {
            currentTool.Use();
        }
    } 
