    public class Test{
        public void DoSomething(Type myClass){
            if(!typeof(Test).IsAssignableFrom(myClass)){
                throw new ArgumentException("myClass must refer to Test or a derived class", "myClass");
            }
        }
    }
