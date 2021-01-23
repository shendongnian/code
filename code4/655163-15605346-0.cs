        public abstract class Foo<T>
        {
            public abstract IList<T> MyList { get; }
            // you can manipulate MyList in this class even if it is defined in inherited class
        }
        public class Bar : Foo<string>
        {
            private readonly IList<string> _myList = new List<string>();
            public override IList<string> MyList
            {
                get { return _myList; }
            }
        }
        [TestFixture]
        public class TestFixture1
        {
            [Test]
            public void Test()
            {
                Bar oBar = new Bar();
                Foo<string> oFoo = oBar;
                oFoo.MyList.Add("Item");
                // oFoo.ListObject= { "Item" }
                // oBar.ListString = { "Item" }
                oBar.MyList.Add("NewItem");
                // oFoo.ListObject= { "Item" }
                // oBar.ListString = { "Item" }
            }
        }
