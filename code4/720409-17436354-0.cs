        public IEnumerable<string> ReadDocument()
        {
            // Iterate over the pages, and use yield return to add every individual page to the IEnumerable.
            // Using the current Page and the PageLength in your for loop removes the need of having to manually check
            // whether we've reached the end of the pages further down the loop.
            for (int i = 0; i < _pages.Length; i++)
            {
                // BarcodeData dataArray = engine.Reader.ReadBarcode(theImage, LogicalRectangle.Empty, 0, null);
                // qrCode = dataArray.Value;
                yield return _pages[i]; // dataArray.Value in your own code.
            }
        }
