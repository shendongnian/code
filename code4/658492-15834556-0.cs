     protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                this.DataContext = null;
                foreach (var obj in this._images)
                {
                    if (obj != null)
                    {
                        obj.ClearValue(BitmapImage.UriSourceProperty);
                    }
                    
                }
               
