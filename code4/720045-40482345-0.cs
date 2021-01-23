        private void decode_QRtag()
        {
            try
            {
                //pictureBox1 shows the web cam video
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
              
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decoded = result.ToString().Trim();        
                //capture a snapshot if there is a match
                PictureBox2.Image = bitmap;
                textBox1.Text = decoded;
            }
            catch 
            {
            }
        }`
