       //FOURIER
       //start is the where in the array to start
       Complex[] DFT(byte[] samples, int samplesCount, int start)
       {
           var = new Complex[samplesCount];
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
               result[f].Real = tem.Real;
               result[f].Imaginary = tem.Imaginary;
           }
           return result;
       }
