    public static class ListExtensions
    {
        public static T[] ConvertToArray<T>(IList list)
        {
            return list.Cast<T>().ToArray();
        }
        public static object[] ConvertToArrayRuntime(IList list, Type elementType)
        {
            var convertMethod = typeof(ListExtensions).GetMethod("ConvertToArray", BindingFlags.Static | BindingFlags.Public, null, new [] { typeof(IList)}, null);
            var genericMethod = convertMethod.MakeGenericMethod(elementType);
            return (object[])genericMethod.Invoke(null, new object[] {list});
        }
    }
    [TestFixture]
    public class ExtensionTest
    {
        [Test]
        public void TestThing()
        {
            IList list = new List<string>();
            list.Add("hello");
            list.Add("world");
            var myArray = ListExtensions.ConvertToArrayRuntime(list, typeof (string));
            Assert.IsTrue(myArray is string[]);
        }
    }
