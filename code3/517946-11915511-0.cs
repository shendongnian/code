    public class ModuleDecorator : IModule
    {
        IModule _subject;
        public ModuleDecorator(IModule subject)
        {
            _subject = subject;
        }
    
        public void Initialize()
        {
            var moduleInfo = new ModuleInformation{ModuleName = "ClassNameHere"};
            splashScreenService.ModuleLoadStart(moduleInfo);
            
            _subject.Initialize();
    
            splashScreenService.ModuleLoadEnd(moduleInfo);
        }
    }
