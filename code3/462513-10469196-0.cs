            //call the method:
            string str = ""; //variable that will be changed accordingly by returned value
            byte[] image = GetPic();
            if (image.Length == 0)
            {
                //do what ever you want, like string = "NULL":
                str = "NULL";
            }
        //
        //
        private byte[] GetPic()
        {
            PictureBox pictureboxstupic = new PictureBox();
            using (var stream = new MemoryStream())
            {
                var bmp = new Bitmap(pictureboxstupic.Image);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                var data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }
