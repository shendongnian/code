    Task<IEnumerable<string>>.Factory.StartNew(() => System.IO.Directory.GetFiles(
                imagePath,
                "*.jpg")).
                ContinueWith(task =>
                            {
                                foreach (var item in task.Result)
                                {
                                    this.Dispatcher.BeginInvoke((Action)(() =>
                                    {
                                        var img = new Image
                                                        {
                                                            Source =
                                                                new BitmapImage(
                                                                new Uri(item))
                                                        };
                                        LayoutRoot.Children.Add(img);
    
                                    }));
    
                                }
                            });
