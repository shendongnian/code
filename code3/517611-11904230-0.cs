    var listBoxItem = listBox.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
                RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)listBoxItem.ActualWidth,
                                                                               (int)listBoxItem.ActualHeight, 96, 96,
                                                                               PixelFormats.Pbgra32);
                renderTargetBitmap.Render(listBoxItem);
                image.Source = renderTargetBitmap;
                image.Width = listBoxItem.ActualWidth;
                image.Height = listBoxItem.ActualHeight;
