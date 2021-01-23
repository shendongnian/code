    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using static LinqTest.LinqCompileSubExpression;
    
    namespace LinqTest
    {
        [TestClass]
        public class LinqCompileSubExpressionTest
        {
            [TestMethod]
            public void InvokeExpressionTest1()
            {
                Expression<Func<string, int>> rootExpression = s => s.Substring(4).Length;
    
                var subExpression = ((MemberExpression)rootExpression.Body).Expression;   // just the `s.Substring(4)` part
                Assert.AreEqual("t string", InvokeSubExpression<string>(rootExpression, subExpression, "input string"));
            }
    
            [TestMethod]
            public void InvokeExpressionTest2()
            {
                Expression<Func<object, int>> rootExpression = x => x.ToString().Length;
    
                var subExpression = ((MemberExpression)rootExpression.Body).Expression;   // just the `x.ToString()` part
                Assert.AreEqual("5", InvokeSubExpression<string>(rootExpression, subExpression, 5));
            }
    
            [TestMethod]
            public void InvokeExpressionTest3()
            {
                Expression<Func<ClassForTest, int>> rootExpression = x => x.StrProperty.Length + 15;
    
                var subExpression = ((BinaryExpression)rootExpression.Body).Right;   // `15`
                Assert.AreEqual(15, InvokeSubExpression<int>(rootExpression, subExpression, new ClassForTest()));  // argument is irrelevant
            }
    
            [TestMethod]
            public void InvokeExpressionTest4()
            {
                Expression<Func<int, int>> rootExpression = x => Math.Abs(x) + ClassForTest.GetLength(x.ToString());
    
                var subExpression = ((BinaryExpression)rootExpression.Body).Right;
                Assert.AreEqual(3, InvokeSubExpression<int>(rootExpression, subExpression, 123));   // we pass root parameter but evaluate the sub-expression only
            }
    
            [TestMethod]
            public void InvokeExpressionTest5()
            {
                Expression<Func<int, int>> rootExpression = x => ClassForTest.GetLength(x.ToString());
    
                var subExpression = ((MethodCallExpression)rootExpression.Body).Arguments[0];        // just the `x.ToString()` part
                Assert.AreEqual("123", InvokeSubExpression<string>(rootExpression, subExpression, 123));  // we pass root parameter but evaluate the sub-expression only
            }
    
            public class ClassForTest
            {
                public string StrProperty { get; set; }
                public static int GetLength(string s) => s.Length;
            }
        }
    }
