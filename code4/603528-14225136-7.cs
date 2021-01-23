            for (float twoMinutes = 120f; twoMinutes > 0; twoMinutes -= 2.4f)
            {
                T += (K2 * 2.4);
                Console.WriteLine("t: {0:F2}, T: {1:F2}", twoMinutes - 2.4f, T);
            }
