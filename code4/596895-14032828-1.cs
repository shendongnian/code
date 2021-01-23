          private static Random rnd = new Random();
        private double[] RandomTerrarain(int length, int sinuses, int cosinuses, double amplsin, double amplcos, double noise)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException("length", length, "Length must be greater than zero!");
            double[] returnValues = new double[length];
            for (int i = 0; i < length; i++)
            {
                // sin
                for (int sin = 1; sin <= sinuses; sin++)
                {
                    returnValues[i] += amplsin * Math.Sin((2 * sin * i * Math.PI) / (double)length);
                }
                // cos
                for (int cos = 1; cos <= cosinuses; cos++)
                {
                    returnValues[i] += amplcos * Math.Cos((2 * cos * i * Math.PI) / (double)length);
                }
                // noise
                returnValues[i] += (noise * rnd.NextDouble()) - (noise * rnd.NextDouble());
            }
            // give offset so it be higher than 0
            double ofs = returnValues.Min();
            if (ofs < 0)
            {
                ofs *= -1;
                for (int i = 0; i < length; i++)
                {
                    returnValues[i] += ofs;
                }
            }
            // resize to be fit in 100
            double max = returnValues.Max();
            if (max >= 100)
            {
                double scaler = max / 100.0;
                for (int i = 0; i < length; i++)
                {
                    returnValues[i] /= scaler;
                }
            }
            return returnValues;
        }
