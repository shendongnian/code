    private async void FilterListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            progressRing.IsActive = true;
            
            try
            {
                var filteredImage = await Task.Run(() => 
                                {
                                    var clonedBitmap = originalImage.Clone();
                                    
                                    using (clonedBitmap.GetBitmapContext())
                                    {
                                       clonedBitmap.ForEach(ImageEdit.toGrayscale);
                                    }
    
                                     return clonedBitmap;
                               });
                mainImage.Source = filteredImage;
            }
            catch
            {
                Debug.WriteLine("No items selected");
            }    
            progressRing.IsActive = false;
        }
