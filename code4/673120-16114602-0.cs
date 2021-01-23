    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest2
        {
            public T Get<T, T2>(string str)
                where T : CanCastFromString<T2>, new()
                where T2 : CanCastFromString<T2>, ICanInitFromString, new()
            {
                return (T)str;
            }
    
            [TestMethod]
            public void Test()
            {
                var result = Get<Foo, Foo>("test");
    
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Foo));
                Assert.AreEqual("test", result.Value);
            }
        }
    
        public class Foo : CanCastFromString<Foo>
        {
            public string Value { get; set; }
    
            public override void InitFromString(string str)
            {
                Value = str;
            }
        }
    
        public abstract class CanCastFromString<T> : ICanInitFromString
            where T : CanCastFromString<T>, ICanInitFromString, new()
        {
            public static explicit operator CanCastFromString<T>(string str)
            {
                var x = new T();
                x.InitFromString(str);
                return x;
            }
    
            public abstract void InitFromString(string str);
        }
    
        public interface ICanInitFromString
        {
            void InitFromString(string str);
        }
    }
