    public abstract class Foo {
        protected IDbOjbect _db;
        private DBType _type;
        public DBType Type {
            get { return _type; }
        }
        public Foo(DBType type) {
            _type = type;
        }
        internal abstract bool RunTest();
        public void Connect(IDbObject db) {
            _db = db;
        }
        public static Foo Create(String type) {
            switch (type) {
                case "oracle": return new FooImpl_Oracle();
            }
            return null;
        }
    }
    public sealed class FooImpl_Oracle : Foo {
        internal FooImpl_Oracle() : base(DBType.Oracle) {
        }
        internal bool RunTest() {
            //do something
            return true;
        }
    }
    [TestFixture("oracle")]
    public class Tests {
        private Foo f;
        public Tests(string conn) {
            f = Foo.Create(conn);
        }
        [SetUp]
        public void SetUp() {
            Mock<IDbObject> db = new Mock<IDbObject>();
            db.Setup(x => x.CurrentDbType).Returns(f.Type);
            f.Connect(db);
        }
        [Test]
        public void TestOne() {
            Assert.IsTrue(f.RunTest());
        }
    }
