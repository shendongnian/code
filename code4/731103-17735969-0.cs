        public void UpdateBitmap()
        {
            WriteableBitmap writeableBitmap = new WriteableBitmap
                                    (100, 100, 96, 96, PixelFormats.Bgr32, null);
            writeableBitmap.Dispatcher.InvokeAsync(() =>
                {
                    Console.WriteLine("work goes here");
                });
        }
