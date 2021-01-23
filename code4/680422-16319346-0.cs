        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var writeableBitmap = new WriteableBitmap(100, 100, 300, 300, PixelFormats.Bgra32, null);
            _image.Source = writeableBitmap;
            new Thread(() =>
                {
                    Thread.Sleep(1000);
                    var pixelHeigth = (Int32)writeableBitmap.Dispatcher.Invoke(
                                                         DispatcherPriority.Background,
                                                        (DispatcherOperationCallback)(arg => ((WriteableBitmap)arg).PixelHeight), writeableBitmap);
                    Debug.Print("PixelHeight:" + pixelHeigth);
                }).Start();
            
        }
