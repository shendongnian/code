    public static class BarcodeScanner
    {
        private static ZxingCameraViewController currentBarcodeScanner;
        public static Task<Result> Scan(UIViewController hostController, MobileBarcodeScanner scanner, MobileBarcodeScanningOptions options)
        {
            return Task.Factory.StartNew(delegate
            {
                Result result = null;
                var scanResultResetEvent = new ManualResetEvent(false);
                hostController.InvokeOnMainThread(delegate
                {
                    // Release previously displayed barcode scanner
                    if (currentBarcodeScanner != null)
                    {
                        currentBarcodeScanner.Dispose();
                        currentBarcodeScanner = null;
                    }
                    currentBarcodeScanner = new ZxingCameraViewController(options, scanner);
                    // Handle barcode scan event
                    currentBarcodeScanner.BarCodeEvent += delegate(BarCodeEventArgs e)
                    {
                        currentBarcodeScanner.DismissViewController();
                        result = e.BarcodeResult;
                        scanResultResetEvent.Set();
                    };
                    // Handle barcode scan cancel event
                    currentBarcodeScanner.Canceled += delegate
                    {
                        currentBarcodeScanner.DismissViewController();
                        scanResultResetEvent.Set();
                    };
                    // Display the camera view controller
                    hostController.PresentViewController(currentBarcodeScanner, true, delegate{});
                });
                // Wait for scan to complete
                scanResultResetEvent.WaitOne();
                return result;
            });
        }
    }
