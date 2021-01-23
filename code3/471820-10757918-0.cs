       oImg.Image = System.Drawing.Image.FromStream(oStream);
       TO THIS
       
       oImg.Image = ImageFromBase64String(psGraphic);
       private Image ImageFromBase64String(string sBase64String)
            {
                using (var sStream = new MemoryStream(Convert.FromBase64String(sBase64String)))
                using (var iSourceImage = Image.FromStream(sStream))
                {
                    return new Bitmap(iSourceImage);
                }
            }
