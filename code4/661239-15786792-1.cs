    Task<Image>.Factory.StartNew(() =>
                {
                    return Bitmap.FromFile("image path here");
                }).ContinueWith(t =>
                    {
                        this.BackgroundImage = t.Result;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
