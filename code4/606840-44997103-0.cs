    private static byte[] byteResim = null;
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resimdosyası seçiniz.";
            openFileDialog1.Filter = "Resim files (*.jpg)|*.jpg|Tüm dosyalar(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string resimYol = openFileDialog1.FileName; // File name of the image
                
                picResim.Image = Image.FromFile(resimYol);// picResim is name of picturebox
                picResim.Image = YenidenBoyutlandir(new Bitmap(picResim.Image)); //this method resizing the image
                Image UyeResim = picResim.Image;   // and this four block converting to image to byte
                MemoryStream ms = new MemoryStream();
                UyeResim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byteResim = ms.ToArray();  // byteResim  variable format  Byte[]
            }
        }
        Image YenidenBoyutlandir(Image resim)// resizing image method 
        {
            Image yeniResim = new Bitmap(150, 156);
            using (Graphics abc = Graphics.FromImage((Bitmap)yeniResim))
            {
                abc.DrawImage(resim, new System.Drawing.Rectangle(0, 0, 150, 156));
            }
            return yeniResim;
        }
