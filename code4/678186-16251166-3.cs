    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                int[] lotoDraw = createDraw();
            
                Shuffler shuffler = new Shuffler();
                shuffler.Shuffle(lotoDraw); // Now they are randomly ordered.
                // We want 6 numbers, so we just draw the first 6:
                int[] loto = draw(lotoDraw, 6);
                // Print them out;
                foreach (int ball in loto)
                    Console.WriteLine(ball);
            }
            private static int[] draw(int[] bag, int n) // Draws the first n items
            {                                           // from the bag
                int[] result = new int[n];
                for (int i = 0; i < n; ++i)
                    result[i] = bag[i];
                return result;
            }
            private static int[] createDraw() // Creates a collection of numbers
            {                                 // from 1..50 to draw from.
                int[] result = new int[50];
                for (int i = 0; i < 50; ++i)
                    result[i] = i + 1;
                return result;
            }
        }
        public class Shuffler
        {
            public void Shuffle<T>(IList<T> list)
            {
                for (int n = list.Count; n > 1; )
                {
                    int k = _rng.Next(n);
                    --n;
                    T temp = list[n];
                    list[n] = list[k];
                    list[k] = temp;
                }
            }
            private readonly Random _rng = new Random();
        }
    }
