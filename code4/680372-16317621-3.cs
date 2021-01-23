    public class Base<T> where T : EntityObject
    {
        protected Helper<T> helper;
    }
    public class Child : Base<MyEntity>
    {
        public Child()
        {
            helper = new Helper<MyEntity>();
        }
    }
