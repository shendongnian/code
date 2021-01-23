    public class BaseClass 
    {
        protected readonly List<string> _someValues;
    }
    public class InheritedClass : BaseClass
    {
        public void NeedsThoseValues()
        {
             DoSomethingWith(_someValues);
        }
    }
