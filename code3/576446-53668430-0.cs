    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Puresharp;
    
    namespace TEST
    {
        /// <summary>
        /// Class to test with NUnit
        /// </summary>
        public class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        }
    
        /// <summary>
        /// Test class for calculator with a simple test.
        /// </summary>
        [TestFixture]
        public class CalculatorTest
        {
            /// <summary>
            /// Static constructor (class constructor) to attach aspect to test method.
            /// </summary>
            static CalculatorTest()
            {
                //Instantiate my custom aspect.
                var myBasicAspect = new MuCustomAspect();
    
                //Attach my custom aspect to my custom pointcut
                myBasicAspect.Weave<MyCustomPointcut>();
            }
    
            [Test]
            public void ShouldAddTwoNumbers()
            {
                var _calculator = new Calculator();
                int _result = _calculator.Add(2, 8);
                Assert.That(_result, Is.EqualTo(10));
            }
        }
    
        /// <summary>
        /// Pointcut to identify methods group to weave (here test methods of CalculatorTest).
        /// </summary>
        public class MyCustomPointcut : Pointcut
        {
            override public bool Match(MethodBase method)
            {
                return method.DeclaringType == typeof(CalculatorTest) && method.GetCustomAttributes(typeof(TestAttribute), true).Any();
            }
        }
    
        /// <summary>
        /// Défine an aspect.
        /// </summary>
        public class MuCustomAspect : Aspect
        {
            public override IEnumerable<Advisor> Manage(MethodBase method)
            {
                //Aspect will advice method on boundary using MyCustomAdvice.
                yield return Advice.For(method).Around(() => new MyCustomAdvice());
            }
        }
    
        /// <summary>
        /// Define an advice.
        /// </summary>
        public class MyCustomAdvice : IAdvice
        {
            public MyCustomAdvice()
            {
            }
    
            public void Instance<T>(T value)
            {
            }
    
            public void Argument<T>(ref T value)
            {
            }
            public void Begin()
            {
            }
            public void Await(MethodInfo method, Task task)
            {
            }
            public void Await<T>(MethodInfo method, Task<T> task)
            {
            }
            public void Continue()
            {
            }
            public void Return()
            {
            }
            public void Return<T>(ref T value)
            {
            }
            public void Throw(ref Exception exception)
            {
            }
            public void Throw<T>(ref Exception exception, ref T value)
            {
            }
            public void Dispose()
            {
            }
        }
    }
