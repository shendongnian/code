    [ComVisible(true)]
    public interface IDictWrapper
    {
        object GetByKey(string key);
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IDictWrapper))]
    public class DictWrapper: Dictionary<string,object>, IDictWrapper
    {
        public object GetByKey(string key)
        {
            return base[key];
        }
    }
