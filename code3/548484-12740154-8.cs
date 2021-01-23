        //FOURIER
        public IEnumerable<Complex> DFT(byte[] samples)
        {
            int samplesLength = samples.Length;
            for (int f = 0; f < samplesLength; f++)
            {
                Complex resultItem = new Complex();
                for (int t = 0; t < samplesLength; t++)
                {
                    resultItem.Real += samples[t] * Math.Cos(2 * Math.PI * t * f / samplesLength);
                    resultItem.Imaginary -= samples[t] * Math.Sin(2 * Math.PI * t * f / samplesLength);
                }
                yield return resultItem;
            }
        }
