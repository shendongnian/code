            var panelPoint = this.MyPanel.PointToScreen(new Point(this.MyPanel.ClientRectangle.X, this.MyPanel.ClientRectangle.Y));
            using (var bitmap = new Bitmap(320, 240))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(320, Point.Empty, new Size(320, 240));
                }
                if (SimpleIoc.Default.ContainsCreated<ICommonApplicationData>())
                {
                    var imageGuidName = Guid.NewGuid();
                    fileName = Path.Combine("C:\", "TestFolder", imageGuidName + ".jpg");
                    bitmap.Save(fileName, ImageFormat.Jpeg);
                    var tempBitmapImage = new BitmapImage();
                    tempBitmapImage.BeginInit();
                    tempBitmapImage.UriSource = new Uri(fileName);
                    tempBitmapImage.EndInit();
                    image.Source = tempBitmapImage;
                }
            }
