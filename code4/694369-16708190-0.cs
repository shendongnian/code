    public class MyCustomList : ArrayList
    {
        public override void Add(object item){
            if(item is Class1 || item is Class2) {
                base.Add(item);
            }
            else {
                throw BadaboomException();
            }
        }
    } 
