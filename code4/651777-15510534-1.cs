    bitm.DecodePixelWidth = 200;
    bitm.DecodePixelHeight = 100;
---
    private void LoadImagesAsync()
            {
                IEnumerable<string> images = System.IO.Directory.GetFiles(IMAGE_FOLDER, "*.jpg").Skip(_PageNumber * NUMBER_OF_IMAGES).Take(NUMBER_OF_IMAGES);
    
                for (int i = 0; i < NUMBER_OF_IMAGES; i++)
                {
                    int j = i;
                    var bitm = new BitmapImage();
    
                    bitm.BeginInit();
                    bitm.CacheOption = BitmapCacheOption.OnLoad;
                    bitm.UriSource = new Uri(images.ElementAt(i));
                    bitm.DecodePixelWidth = 200;
                    bitm.DecodePixelHeight = 100;
                    bitm.EndInit();
    
                    ImageBrush brush = new ImageBrush(bitm);
                    brush.Freeze();
    
                    this.Dispatcher.BeginInvoke(new Action(() => 
                    {
                        Grid grid = (Grid)grd_photoBox.Children[j];
    
                        var rectangle = (from e in grid.Children.OfType<Rectangle>()
                                            where e is Rectangle
                                            select e).First();
    
                        rectangle.Fill = brush;
                    }));
                }
            }
