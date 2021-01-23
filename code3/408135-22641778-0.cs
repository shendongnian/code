        public class Demo
        {
            int a, b;
            public Demo(int _a, int _b)
            {
                this.a = _a;
                this.b = _b;
            }
            public int Sum()
            {
                return this.a + this.b;
            }
        }
        public abstract class DemoTestBase
        {
            Demo objUnderTest;
            int expectedSum;
            public DemoTestBase(int _a, int _b, int _expectedSum)
            {
                objUnderTest = new Demo(_a, _b);
                this.expectedSum = _expectedSum;
            }
            [TestMethod]
            public void test()
            {
                Assert.AreEqual(this.expectedSum, this.objUnderTest.Sum());
            }
        }
        [TestClass]
        public class DemoTest_A12_B4 : DemoTestBase
        {
            public DemoTest_A12_B4() : base(12, 4, 16) { }
        }
        public abstract class DemoTest_B10_Base : DemoTestBase
        {
            public DemoTest_B10_Base(int _a) : base(_a, 10, _a + 10) { }
        }
        [TestClass]
        public class DemoTest_B10_A5 : DemoTest_B10_Base
        {
            public DemoTest_B10_A5() : base(5) { }
        }
