    namespace MyCompany.MyProject.UnitTests.WorkflowStepsTests
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Threading.Tasks;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using FluentAssertions;
    
        [TestClass]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public class MyAbstractClassTests
        {
            [TestMethod]
            public void ConstructorILoggerFactoryIsNullTest()
            {
                Action a = () => new MyUnitTestConcreteClass(null);
                a.Should().Throw<ArgumentNullException>().WithMessage(MyAbstractClass<int>.ErrorMessageILoggerFactoryIsNull);
    
            }
    
            [TestMethod]
            public void GetABooleanIsTrueTest()
            {
    			/* here is more likely what you want to test..an implemented method on the abstract class */
    			Mock<ILoggerFactory> iloggerFactoryMock = this.GetDefaultILoggerFactoryMock();
                MyUnitTestConcreteClass testItem = new MyUnitTestConcreteClass(iloggerFactoryMock.Object);
                Assert.IsTrue(testItem.GetABoolean());
            }	
    		
            [TestMethod]
            public void GetSomeIntsIsNotNullTest()
            {
    			/* you may not want to test the abstract methods, but you can */
    			Mock<ILoggerFactory> iloggerFactoryMock = this.GetDefaultILoggerFactoryMock();
                MyUnitTestConcreteClass testItem = new MyUnitTestConcreteClass(iloggerFactoryMock.Object);
                Assert.IsNotNull(testItem.GetSomeInts());
            }		
    		
    		
            private Mock<ILoggerFactory> GetDefaultILoggerFactoryMock()
            {
                Mock<ILoggerFactory> returnMock = new Mock<ILoggerFactory>(MockBehavior.Strict);
                ////returnMock.Setup(x => x.SomeBooleanMethod()).Returns(true);
                return returnMock;
            }		
    		
    		
    
            internal class MyUnitTestConcreteClass : MyAbstractClass<int>
            {
                internal MyUnitTestConcreteClass(ILoggerFactory loggerFactory) : base(loggerFactory)
                {
                }
    
                public override ICollection<int> GetSomeInts()
                {
                    new List<int> { 111, 222, 333 };
                }
            }
        }
    }
