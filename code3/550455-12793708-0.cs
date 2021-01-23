    public struct Foo
    {
        public static readonly Foo Default = new Foo("Default text...");
        public Foo(string text)
        {
            mText = text;
            mInitialized = true;
        }
        public string Text
        {
            get
            {
                if (mInitialized)
                {
                    return mText;
                }
                return Default.mText;
            }
            set { mText = value; }
        }
        private string mText;
        private bool mInitialized;
    }
***
    [TestClass]
    public class FooTest
    {
        [TestMethod]
        public void TestDefault()
        {
            var o = default(Foo);
            Assert.AreEqual("Default text...", o.Text);
        }
    }
