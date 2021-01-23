        public void UpdateBitmap()
        {
            object[] objs = new object[] {null};
            WriteableBitmap writeableBitmap = new WriteableBitmap(
                 100, 100, 96, 96, PixelFormats.Bgr32, null);
            writeableBitmap.Dispatcher.BeginInvoke((SendOrPostCallback)delegate
                {
                    Console.WriteLine(@"work goes here");
                }, objs);
        }
