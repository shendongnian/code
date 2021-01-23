    public class MyWrapper {
        public double? Value {get;set;}
    }
    Dictionary<string, MyWrapper> lookup = ...
    MyWrapper someField = new MyWrapper();
    lookup.Add("foo", someField);
