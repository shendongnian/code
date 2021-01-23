      public Task ReleaseSingleImageMemoryTask(MyImage myImage, object control)
        {
            Pivot myPivot = control as Pivot;
            Task t = Task.Factory.StartNew(() =>
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (myImage.img.UriSource != null)
                    {
                        myImage.img.UriSource = null;
                        DisposeImage(myImage.img);
                    }
                    PivotItem it = (PivotItem)(myPivot.ItemContainerGenerator.ContainerFromIndex(myImage.number % 10));
                    Image img = FindFirstElementInVisualTree<Image>(it);
                    if (img != null)
                    {
                        img.Source = null;
                        GC.Collect();
                    }
                });
                myImage.released = true;
            });
            return t;
        } 
    private T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
        private void DisposeImage(BitmapImage img)
        {
            if (img != null)
            {
                try
                {
                    using (var ms = new MemoryStream(new byte[] { 0x0 }))
                    {
                        img = new BitmapImage();
                        img.SetSource(ms);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ImageDispose FAILED " + e.Message);
                }
            }
        }
