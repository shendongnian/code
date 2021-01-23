    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.Collections;
    using System.Collections.Concurrent;
    
    namespace RandomiseArray
    {
        static class Program
        {
            static void Main(string[] args)
            {
                // source array
                string[] s = new string[] { "a", "b", "c", "d", "e", "f", "g" };
    
                // number of unique random combinations required
                int combinationsRequired = 5;
                var randomCombinations = s.Randomise(System.Text.UnicodeEncoding.Unicode.GetBytes, combinationsRequired);
    
                foreach (var c in randomCombinations)
                    Console.WriteLine(c.Aggregate((x, y) => x + "," + y));
    
                Console.ReadLine();
            }
    
            /// <summary>
            /// given a source array and a function to convert any item in the source array to a byte array, produce x unique random sequences
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="source"></param>
            /// <param name="byteFunction"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static IEnumerable<IEnumerable<T>> Randomise<T>(this IEnumerable<T> source, Func<T, byte[]> byteFunction, int x)
            {
                var foundValues = new ConcurrentDictionary<byte[], T[]>();
                int found = 0;
                do
                {
                    T[] y = source.Randomise().ToArray();
                    var h = y.Hash(byteFunction);
                    if (!foundValues.Keys.Contains(h))
                    {
                        found++;
                        foundValues[h] = y;
                        yield return y;         // guaranteed unique combination  (well, within the collision scope of SHA512...)
                    }
                } while (found < x);
            }
    
            public static IEnumerable<T> Randomise<T>(this IEnumerable<T> source)
            {
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                    return source.OrderBy(i => rng.Next());
            }
    
            public static int Next(this RNGCryptoServiceProvider rng)
            {
                byte[] buf = new byte[4];
                rng.GetBytes(buf);
                return BitConverter.ToInt32(buf, 0);
            }
    
            public static byte[] Hash<T>(this IEnumerable<T> items, Func<T, byte[]> getItemBytes)
            {
                using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider())
                    return sha.ComputeHash(items.SelectMany(i => getItemBytes(i)).ToArray());
            }
        }
    }
