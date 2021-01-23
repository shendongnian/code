     UIGraphics.BeginImageContext(UIScreen.MainScreen.Bounds.Size);
            try
            {
                var mainLayer = UIApplication.SharedApplication.KeyWindow.Subviews[0].Layer;
                mainLayer.RenderInContext(UIGraphics.GetCurrentContext());
                var img = UIGraphics.GetImageFromCurrentImageContext();
                img.SaveToPhotosAlbum((iRef, status) =>
                {
                    if (status != null)
                    {
                        new UIAlertView("Problem", status.ToString(), null, "OK", null).Show();
                    }
                    else
                    {
                        new UIAlertView("Saved", "Saved", null, "OK", null).Show();
                    }
                });
            }
            finally
            {
                UIGraphics.EndImageContext();
            }
