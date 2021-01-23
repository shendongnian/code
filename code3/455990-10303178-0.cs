    using System;
    using System.Text;
    using NUnit.Framework;
    
    namespace ProofOfConcept.GenericInterpolation
    {
        /// <summary>
        /// Proof of concept for a generic Interpolate.
        /// </summary>
        [TestFixture]
        public class GenericInterpolationTest
        {
            /// <summary>
            /// Interpolate test.
            /// </summary>
            [Test]
            public void InterpolateTest()
            {
                Int16 interpolInt16 = Interpolate<Int16>(2, 4, 5, 6, 7);
                Int32 interpolInt32 = Interpolate<Int32>(2, 4, 5, 6, 7);
    
                Double interpolDouble = Interpolate<Double>(2, 4, 5, 6, 7);
                Decimal interpolDecimal = Interpolate<Decimal>(2, 4, 5, 6, 7);
    
                Assert.AreEqual((Int16)interpolInt32, (Int16)interpolInt16);
                Assert.AreEqual((Double)interpolDouble, (Double)interpolDecimal);
    
                //performance test
                int qtd = 100000;
                DateTime beginDt = DateTime.Now;
                TimeSpan totalTimeTS = TimeSpan.Zero;
                for (int i = 0; i < qtd; i++)
                {
                    interpolDouble = Interpolate(2, 4, 5, 6, 7);
                }
                totalTimeTS = DateTime.Now.Subtract(beginDt);
                Console.WriteLine(
                    "Non Generic Single, Total time (ms): " + 
                    totalTimeTS.TotalMilliseconds);
    
                beginDt = DateTime.Now;
                for (int i = 0; i < qtd; i++)
                {
                    interpolDouble = Interpolate<Double>(2, 4, 5, 6, 7);
                }
                totalTimeTS = DateTime.Now.Subtract(beginDt);
                Console.WriteLine(
                    "Generic, Total time (ms): " + 
                    totalTimeTS.TotalMilliseconds);
            }
    
            /// <summary>
            /// Interpolates the specified x1.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="x1">The x1.</param>
            /// <param name="y1">The y1.</param>
            /// <param name="x2">The x2.</param>
            /// <param name="y2">The y2.</param>
            /// <param name="x">The x.</param>
            /// <returns></returns>
            public static T Interpolate<T>(T x1, T y1, T x2, T y2, T x) where T : IConvertible
            {
                IConvertible x1C = x1 as IConvertible;
                IConvertible y1C = y1 as IConvertible;
                IConvertible x2C = x2 as IConvertible;
                IConvertible y2C = y2 as IConvertible;
                IConvertible xC = x as IConvertible;
                Decimal retDec = y1C.ToDecimal(null) + 
                   (xC.ToDecimal(null) - x1C.ToDecimal(null)) * 
                   (y2C.ToDecimal(null) - y1C.ToDecimal(null)) / 
                   (x2C.ToDecimal(null) - x1C.ToDecimal(null));
    
                return (T)((IConvertible)retDec).ToType(typeof(T), null);
            }
    
            /// <summary>
            /// Interpolates the specified x1.
            /// </summary>
            /// <param name="x1">The x1.</param>
            /// <param name="y1">The y1.</param>
            /// <param name="x2">The x2.</param>
            /// <param name="y2">The y2.</param>
            /// <param name="x">The x.</param>
            /// <returns></returns>
            public static Single Interpolate(Single x1, Single y1, Single x2, Single y2, Single x)
            {
                Single retSing = y1 + (x - x1) * (y2 - y1) / (x2 - x1);
    
                return retSing;
            }
        }
    }
