    public class MyClass {
    ...    
    
        private List<SomeClass> _myProperty = null;
        public List<SomeClass> MyProperty {
            get { 
                if (_myProperty == null) _myProperty = SomeClass.GetCollectionOfThese(someId);
                return _myProperty;
            } 
        }
    ...
    }
