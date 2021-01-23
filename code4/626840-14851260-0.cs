            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.CODE_128;
            var options = new EncodingOptions();
            options.Height = 140;
            options.Width = 300;
            writer.Options = options;
            try
            {
                Bitmap image = writer.Write(textBoxCodigoDeBarras.Text);
                BitmapImage bi = ImageManager.BitmapToImagesource(image);
                ImageCodigoDeBarras.Source = bi;
            }
            catch
            {
                //Could not generate image.
                //Therefone Barcode is invalid.
            }
