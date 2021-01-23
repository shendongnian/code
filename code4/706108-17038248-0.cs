     private void DragImage(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);
            DragDrop.DoDragDrop(image, data, DragDropEffects.All);
            moving = true;
        }
        private void DropImage(object sender, DragEventArgs e)
        {
            Image imageControl = new Image();
            if ((e.Data.GetData(typeof(ImageSource)) != null))
            {
                ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
                imageControl = new Image() { Width = 50, Height = 30, Source = image };
            }
            else
            {
                if ((e.Data.GetData(typeof(Image)) != null))
                {
                    Image image = e.Data.GetData(typeof(Image)) as Image;
                    imageControl = image;
                    if (this.Canvas.Children.Contains(image))
                    {
                        this.Canvas.Children.Remove(image);
                    }
                }
            }
            Canvas.SetLeft(imageControl, e.GetPosition(this.Canvas).X);
            Canvas.SetTop(imageControl, e.GetPosition(this.Canvas).Y);
            imageControl.MouseLeftButtonDown += imageControl_MouseLeftButtonDown;
            this.Canvas.Children.Add(imageControl);
        }
        void imageControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(Image), image);
            DragDrop.DoDragDrop(image, data, DragDropEffects.All);
            moving = true;
        }
