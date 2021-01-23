    public override void Terminate()
    {
        // If you have a scanner
        if(barcodeScanner  != null) 
        {
            barcodeScanner.ScanDeinit();
            // Any other necessary code for cleaning up...
            // Free it up
            barcodeScanner.Dispose();
            // Indicate that you no longer have a scanner
            barcodeScanner = null;
        }
    }
