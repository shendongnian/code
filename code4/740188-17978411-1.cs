    public class MySessionContainer {
        private IList<SomeBusinessObjectType> _BusinessObjectList;
        public IList<SomeBusinessObjectType> BusinessObjectList {
            get { return (_BusinessObjectList ?? 
                      (_BusinessObjectList = new List<SomeBusinessObjectType>()) ; }
            set { _BusinessObjectList = value; }
        }
    }
