    public class MyClass : MyBase
    {
        public MyClass(MyBase source)
        {
            Mapper.Map(source, this);
        }
    }
