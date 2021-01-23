    public class OggDFT
    {
        int sample_length;
        byte[] samples;
        DragonOgg.MediaPlayer.OggFile f;
        int rate = 0;
        System.Numerics.Complex[][] frequencies;
        DiscreteFourierTransform dft = new DiscreteFourierTransform();
        int samplespacing = 128;
        int samplesize = 1024;
        int sampleCount;
        public void ExampleLowpass()
        {
            int shiftUp = 1000; //1khz
            int fade = 2; //8 sample fade.
            int halfsize = samplesize / 2;
            int kick = frequencies[0].Length * shiftUp / rate;
            for (int i = 0; i < sampleCount; i++)
            {
                for (int j = 0; j < frequencies[i].Length; j++)
                {
                    if (j == 0 || j == halfsize)
                        continue;
                    if (j < halfsize)
                    {
                        if (!(j < kick + 1))
                        {
                            frequencies[i][j] = 0;
                        }
                    }
                    else
                    {
                        if (!(j - halfsize > halfsize - 1 - kick))
                        {
                            frequencies[i][j] = 0;
                        }
                    }
                }
                dft.BluesteinInverse(frequencies[i], MathNet.Numerics.IntegralTransforms.FourierOptions.Default);
            }
        }
        public OggDFT(DragonOgg.MediaPlayer.OggFile f)
        {
            Complex[] c = new Complex[10];
            for (int i = 0; i < 10; i++)
                c[i] = i;
            ShiftComplex(-2, c, 5, 10);
            this.f = f;
            //Make a 20MB buffer.
            samples = new byte[20000000];
            int sample_length = 0;
            //This block here simply loads the uncompressed data from the ogg file into a nice n' large 20MB buffer. If you want to use the same library as I've used, It's called DragonOgg (If you cant tell by the namespace)
            while (sample_length < samples.Length)
            {
                var bs = f.GetBufferSegment(4096); //Get ~4096 bytes (does not gurantee that 4096 bytes will be returned.
                if (bs.ReturnValue == 0)
                    break; //End of file
                //Set the rate
                rate = bs.RateHz;
                
                //Display some loading info:
                Console.WriteLine("seconds: " + sample_length / rate);
                //It's stereo so we want half the data.
                int max = bs.ReturnValue / 2;
                //Buffer overflow care.
                if (samples.Length - sample_length < max)
                    max = samples.Length - sample_length;
                //The copier.
                for (int j = 0; j < max; j++)
                {
                    //I'm using j * 2 here because I know that the input audio is 8Bit Stereo, and we want just one mono channel. So we skip every second one.
                    samples[sample_length + j] = bs.Buffer[j * 2];
                }
                sample_length += max;
                if (max == 0)
                    break;
            }
            sampleCount = (sample_length - 1) / samplespacing + 1;
            frequencies = new System.Numerics.Complex[sampleCount][];
            for (int i = 0; i < sample_length; i += samplespacing)
            {
                Console.WriteLine("Sample---" + i + " / " + sample_length);
                System.Numerics.Complex[] sample;
                if (i + samplesize > sample_length)
                    sample = new System.Numerics.Complex[sample_length - i];
                else
                    sample = new System.Numerics.Complex[samplesize];
                for (int j = 0; j < sample.Length; j++)
                {
                    sample[j] = (float)(samples[i + j] - 128) / 128.0f;
                }
                dft.BluesteinForward(sample, MathNet.Numerics.IntegralTransforms.FourierOptions.Default);
                frequencies[i / samplespacing] = sample;
            }
            //Perform the filters to the frequencies
            ExampleLowpass();
            //Make window kernel thingy
            float[] kernel = new float[samplesize / samplespacing * 2];
            for (int i=0; i<kernel.Length; i++)
            {
                kernel[i] = (float)((1-Math.Cos(2*Math.PI*i/(kernel.Length - 1)))/2);
            }
            //Apply window kernel thingy
            for (int i = 0; i < sample_length; i++)
            {
                int jstart = i / samplespacing - samplesize / samplespacing + 1;
                int jend = i / samplespacing;
                if (jstart < 0) jstart = 0;
                float ktotal = 0;
                float stotal = 0;
                for (int j = jstart; j <= jend; j++)
                {
                    float kernelHere = 1.0f;
                    if (jstart != jend)
                        kernelHere = kernel[(j - jstart) * kernel.Length / (jend + 1 - jstart)];
                    int index = i - j * samplespacing;
                    stotal += (float)frequencies[j][index].Real * kernelHere;
                    ktotal += kernelHere;
                }
                if (ktotal != 0)
                {
                    stotal /= ktotal;
                    samples[i] = (byte)(stotal * 128 * 0.9f + 128);
                }
                else
                {
                    Console.WriteLine("BAD " + jstart + " " + jend + " sec: " + ((float)i / rate));
                    samples[i] = (byte)(stotal * 128 * 0.9f + 128);
                }
            }
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("sound"));
            for (int i = 0; i < sample_length; i++)
            {
                bw.Write(samples[i]);
            }
            bw.Close();
        }
    }
