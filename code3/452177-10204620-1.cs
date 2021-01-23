    [TestFixture] 
    public class StructureMapTests 
    { 
    	[Test] 
    	public void Test_same_interface_default_implemenation_and_with_parameter() 
    	{ 
    		IMyInterface defaultImp = new MyImpl(0);
            ObjectFactory.Initialize(x =>
                                         {
                                             x.For<IMyInterface>().Add<MyInterface>().Named("withArgument").Ctor<int>().IsTheDefault();                                        
                                             x.For<IMyInterface>().Use(defaultImp).Named("default");
                                         });
    
            Assert.AreEqual(defaultImp, ObjectFactory.GetInstance<IMyInterface>());
    
            var instance1 = ObjectFactory.With("value").EqualTo(1).GetInstance<IMyInterface>("withArgument");
            Assert.AreEqual(true, instance1 is MyInterface); 
            Assert.AreEqual(1, instance1.GetValue());
    
            var instance2 = ObjectFactory.With("value").EqualTo(2).GetInstance<IMyInterface>("withArgument");
            Assert.AreEqual(true, instance2 is MyInterface);
            Assert.AreEqual(2, instance2.GetValue());
        }
    
        public interface IMyInterface
        {
            int GetValue();
        }
    
        private class MyInterface : IMyInterface
        {
            private int _value;
    
            public MyInterface(int value)
            {
                _value = value;
            }
    
            public int GetValue()
            {
                return _value;
            }
        }
    }
