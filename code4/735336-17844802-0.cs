    public class Foo{   
        public Baz Bar(){
            var value = BarInternal();
            DoSomethingFirst(value);
            return value;
        }
    
        protected virtual Baz BarInternal(){
            return GetStandardBaz();
        }
    }
