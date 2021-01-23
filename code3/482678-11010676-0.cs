    public class Robot
    {
        private IList<Tool> tools = new List<Tool>();
        public void PickUpTool(Tool newTool)
        {
            // you might check here if he already has the tool being added
            tools.Add(newTool);
        }
        public void DropTool(Tool oldTool)
        {
            // you should check here if he's holding the tool he's being told to drop
            tools.Remove(newTool);
        }
        public void UseTool(Tool toolToUse)
        {
            // you might check here if he's holding the tool,
            // or automatically add the tool if he's not holding it, etc.
            toolToUse.Use();
        }
    }
    public interface Tool
    {
        void Use();
    }
    public class Knife : Tool
    {
        public void Use()
        {
            // do some cutting
        }
    }
    public class Hammer : Tool
    {
        public void Use()
        {
            // do some hammering
        }
    }
