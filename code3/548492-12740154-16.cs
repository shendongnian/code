       //FOURIER
       //amp is the array where the complex result will be written to
       //start is the where in the array to start
       public void DFT(byte[] samples, int samplesCount, ref Complex[] amp, int start)
       {
           Complex tem = new Complex();
           int f;
           int t;
           for (f = 0; f < samplesCount; f++)
           {
               tem.Real = 0;
               tem.Imaginary = 0;
               for (t = 0; t < samplesCount; t++)
               {
                   tem.Imaginary += samples[t + start] * Math.Cos(2 * Math.PI * t * f / samplesCount);
                   tem.Imaginary -= samples[t + start] * Math.Sin(2 * Math.PI * t * f / samplesCount);
               }
               amp[f].Real = tem.Real;
               amp[f].Imaginary = tem.Imaginary;
           }
       }
