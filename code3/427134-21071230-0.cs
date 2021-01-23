      var image = .... // reference to animage on the UI
      var placeholder = ... // a placeholder BitmapImage
      image.Source = placeholder;
            var source = ... // uri to download
            if (source != null)
            {
                var src = new BitmapImage(new Uri(source));
                src.ImageOpened += (s, ee) =>
                {
                    var bi = s as BitmapImage;
                    image.Source = bi;
                };
                image.Source = src;
                // DELAY REQUIRED TO KICK OFF DOWNLOAD
                await Task.Delay(1);
                image.Source = placeholder;
            }
