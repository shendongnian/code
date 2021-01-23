    public enum MyEnum
    {
        Three = 3,
        Seven = 7
    }
    public static class MyExtensions
    {
        public static int ToInt<T>(this T value)
        {
            return Convert.ToInt32(value);
        }
    }
    [TestFixture]
    public class CodeTests
    {
        public int GetInt<T>(T value)
        {
            return Convert.ToInt32(value);
        }
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(7, GetInt(MyEnum.Seven));
        }
        [Test]
        public void TestTwo()
        {
            Assert.AreEqual(7, MyEnum.Seven.ToInt());
        }
    }
