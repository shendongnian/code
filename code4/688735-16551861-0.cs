    public class ModuleScreen : IModuleScreenData
    {
        string IModuleScreenData.Name
        {
            set { Name = value; }
        }
        public string Name { get; private set; }
    }
