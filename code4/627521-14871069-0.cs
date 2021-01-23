        public class BaseClass<T> where T: MyBase, new()
        {
            public BaseClass() { }
            protected virtual T WorkField { get { return new T(); } }
            public int WorkProperty { get { return WorkField.Value; } }
        }
        public class DerivedClass : BaseClass<MyExtend>
        {
            public DerivedClass() : base() { }
            protected override MyExtend WorkField { get { return new MyExtend(); } }
            //public new int WorkProperty
            //{
            //    get { return 0; }
            //}
        }
        public class MyBase
        {
            public MyBase()
            {
            }
            public int Value = 1;
        }
        public class MyExtend : MyBase
        {
            public int value = 20;
        }
