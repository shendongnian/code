    TestStack.Class1
    TestStack.Program
----------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    namespace TestStack
    {
        class Class1
        {
            public void Method1()
            {
                var obj = new TestClass();
                obj.TestMethod1();
            }
        }
        class TestClass
        {
            public void TestMethod1()
            {
                TestMethod2();
            }
            private void TestMethod2()
            {
                StackTrace st = new StackTrace();
                Type calling = null;
                foreach (var sf in st.GetFrames())
                {
                    var type = sf.GetMethod().DeclaringType;
                    if (type != this.GetType())
                    {
                        calling = type;
                        break;
                    }
                }
                Console.WriteLine(calling);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Class1 class1 = new Class1();
                class1.Method1();
                TestClass testClass = new TestClass();
                testClass.TestMethod1();
            }
        }
    }
