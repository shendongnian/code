    using System;
    using NUnit.Framework;
    namespace EC_Connect_Test
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                string fullPath = System.Reflection.Assembly.GetAssembly(typeof(Program)).Location;
                NUnit.Gui.AppEntry.Main(new string[] { fullPath });
            }
        }
            public class MathClass
            {
                internal static double Divide(int A, int B)
                {
                    if (B == 0) throw new DivideByZeroException();
                    return (Double)A / (Double)B;
                }
            }
    
            [TestFixture]
            class MyFirstTestClass
            {
                [Test]
                public void DividingTwoIntegersResultIsDouble()
                {
                    Double expected = 3.3;
                    Double actual = MathClass.Divide(33, 10);
                    Assert.AreEqual(expected, actual);
                }
    
                [Test]
                public void DividingByZeroShouldThrow()
                {
                    Assert.Throws<DivideByZeroException>(
                        () => { MathClass.Divide(33, 0); }
                    );
                }
            }
    
        }
