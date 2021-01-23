     [TestFixture]
    public class ServiceStackTests
    {
        [TestCase]
        public void Foo()
        {
            FakeB b = new FakeB();
            b.Property1 = "1";
            b.Property2 = "2";
            string raw = b.ToJson();
            FakeA a=raw.FromJson<FakeA>();
            Assert.IsNotNull(a);
            Assert.AreEqual(a.GetType(), typeof(FakeB));
        }
    }
    public abstract class FakeA
    {
        public string Property1 { get; set; }
    }
    public class FakeB:FakeA
    {
        public string Property2 { get; set; }
    }
