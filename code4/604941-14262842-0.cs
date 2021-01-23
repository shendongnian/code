    public class BaseClass<T> where T : BaseClass<T>.Settings, new()
    {
        protected Settings settings;
    
        public BaseClass()
        {
            settings = new T();
        }
    
        public virtual void PrintSettings()
        {
            var t = settings.GetType();
            Console.WriteLine(string.Join(", ", t.GetProperties().Select(pi => pi.Name)));
        }
    
        public class Settings
        {
            public string BaseClassSetting
            {
                get { return "BaseClassSetting."; }
            }
        }
    }
    
    public class InheritedClass : BaseClass<InheritedClass.Settings>
    {
        public new class Settings : BaseClass<InheritedClass.Settings>.Settings
        {
            public string InheritedClassSetting
            {
                get { return "InheritedClassSetting!"; }
            }
        }
    }
