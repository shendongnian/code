    public class Poco
    {
        public int Foo;
        public int Bar;
    }
    public class PocoLogic : IPocoLogic
    {
        private IService _service; 
        public PocoLogic(IService service)
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
        private IPocoLogic _logicForSomething;
        public SomethingThatUsesAPoco(IPocoFactory pocoFactory,  IPocoLogic logicForSomething)
        {
            _poco = pocoFactory.CreateInstance();  
        }
        public Result DoIt()
        {
            return _logicForSomething.DoSomethingWithPoco(_poco);
        }
    }
