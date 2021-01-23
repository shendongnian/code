     private void rtfImage_Paint(object sender, PaintEventArgs e)
        {
            string rtfStr = System.IO.File.ReadAllText("MySampleFile.rtf");
            string imageDataHex = ExtractImgHex(rtfStr);
            byte[] imageBuffer = ToBinary(imageDataHex);
            Image image;
            using (MemoryStream stream = new MemoryStream(imageBuffer))
            {
                image = Image.FromStream(stream);
            }
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            e.Graphics.DrawImage(image, rect);                        
        }
