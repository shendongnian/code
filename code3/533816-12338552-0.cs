    public static class ArrayExtensions
    {
        public static Action<int> CreateSetter(this int[] array, int index)
        {
            return (value) => array[index] = value;
        }
    }
    [TestFixture]
    public class ArrayTest
    {
        [Test]
        public void Test()
        {
            int[] myArray = {21,21,364,658,87};
            Action<int> rr = myArray.CreateSetter(1);
            rr(500);
            Assert.AreEqual(500, myArray[1]);
        }
    }
