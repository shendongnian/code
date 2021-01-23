    QRCodeReader reader = new QRCodeReader();
           Bitmap bmp = new Bitmap(@"2.bmp");
            LuminanceSource s = new RGBLuminanceSource(bmp, bmp.Width, bmp.Height);
            BinaryBitmap bb = new BinaryBitmap(new GlobalHistogramBinarizer(s));
            Hashtable hints = new Hashtable();
           
            Result result = reader.decode(bb);
            MessageBox.Show(result.Text); 
       
