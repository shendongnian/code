       //FOURIER
       //start is the where in the array to start
       Complex[] DFT(byte[] samples, int samplesCount, int start)
       {
           var result = new Complex[samplesCount];
           Complex tem = new Complex();
           for (int f = 0; f < samplesCount; f++)
           {
               tem.Real = 0;
               tem.Imaginary = 0;
               for (int t = 0; t < samplesCount; t++)
               {
                   tem.Imaginary += samples[t + start] * Math.Cos(2 * Math.PI * t * f / samplesCount);
                   tem.Imaginary -= samples[t + start] * Math.Sin(2 * Math.PI * t * f / samplesCount);
               }
               result[f] = tem;
           }
           return result;
       }
