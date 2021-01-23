        private byte[] ReverseFrameInPlace2(int stride, byte[] framePixels)
        {
            System.Diagnostics.Stopwatch s = System.Diagnostics.Stopwatch.StartNew();
            var reversedFramePixels = new byte[framePixels.Length];
            var lines = framePixels.Length / stride;
            for (var line = 0; line < lines; line++)
            {
                Array.Copy(framePixels, framePixels.Length - ((line + 1) * stride), reversedFramePixels, line * stride, stride);
            }
            s.Stop();
            System.Console.WriteLine("ReverseFrameInPlace2: {0}", s.Elapsed);
            return reversedFramePixels;
        }
