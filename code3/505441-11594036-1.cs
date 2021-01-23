            double harmonic = 0;
            int partialSumsUpTo = 10000;
            for (double i = 1; i <= partialSumsUpTo; ++i)
            {
                double part = 1 / i;
                harmonic += Math.Round(part, 5);
            }
