    public class Poco
    {
        public int Foo;
        public int Bar;
    }
    public class PocoUtility : IPocoUtility
    {
        private IService _service; 
        public PocoUtility(IService service)
        {   
            _service = service;
        }
        public Result DoSomethingWithPoco(Poco poco)
        {
            return _service.Convert(poco);
        }
    }
    public class SomethingThatUsesAPoco
    {
        private IPocoUtility _logicForSomething;
        public SomethingThatUsesAPoco(IPocoFactory pocoFactory,  IPocoUtility logicForSomething)
        {
            _poco = pocoFactory.CreateInstance();  
        }
        public Result DoIt()
        {
            return _logicForSomething.DoSomethingWithPoco(_poco);
        }
    }
