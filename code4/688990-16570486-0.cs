    private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
            {
                if (((e.Angle <= 180 && e.Angle >= 135) || (e.Angle < 225 && e.Angle > 180)) && e.Direction.ToString().Equals("Horizontal"))
                {
                    if (index < photoslist.Count - 1)
                    {
                        index++;
                        downloadImage();
                    }
                    //image_big.Source = new BitmapImage(new Uri( photoslist[index].LargeUrl , UriKind.Absolute));
                }
                else if (((e.Angle <= 45 && e.Angle >= 0) || (e.Angle < 360 && e.Angle >= 315)) && e.Direction.ToString().Equals("Horizontal"))
                {
                    if (index > 0)
                    {
                        index--;
                        downloadImage();
                    }
                    //image_big.Source = new BitmapImage(new Uri( photoslist[index].LargeUrl, UriKind.Absolute));
                    
                }
            }
    
            private void downloadImage()
            {
                progess_bar.Visibility = Visibility.Visible;
                WebClient wc = new WebClient();
                wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
                wc.OpenReadAsync(new Uri(photoslist[index].LargeUrl, UriKind.Absolute), wc);
            }
    
            private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
            {
                if (e.Error == null && !e.Cancelled)
                {
                    try
                    {
                        BitmapImage image = new BitmapImage();
                        image.SetSource(e.Result);
                        image_big.Source = image;
                        progess_bar.Visibility = Visibility.Collapsed;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot get the feed right now.Please try later.");
                    }
                }
            }
        }
