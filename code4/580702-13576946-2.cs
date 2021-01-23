            var r = new Random();
            var di = new DirectoryInfo(folderbrowser.SelectedPath);
            var fi = di.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
            for (var i = 0; i < imageCount; i++)
            {
                var img1 = r.Next(imageCount);
                var img2 = r.Next(imageCount);
                while (img2 == img1) 
                {
                    img2 = r.Next(imageCount);
                }
                pic1.Image = Image.FromFile(fi[img1].FullName);
                pic2.Image = Image.FromFile(fi[img2].FullName);
                var i1 = pic1.Image;
                var i2 = pic2.Image;
                using (var bitmap = new Bitmap(i1.Width + i2.Width, 1080))
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(i1, 0, 0);
                    g.DrawImage(i2, i2.Width, 0);
                    bitmap.Save(@"C:\TEST\Image_"+i.ToString());
                }                   
            }
