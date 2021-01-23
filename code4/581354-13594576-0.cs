            public static void Clouds(Canvas canvas, int boundry)
            {
                var random = new Random();
                foreach (var image in canvas.Children.OfType<Image>())
                {
                    if (image.Name.Contains("cloud_"))
                    {
                        if (Canvas.GetLeft(image) < canvas.ActualWidth + image.Width)
                        {
                            Canvas.SetLeft(image, Canvas.GetLeft(image) + 1);
                        }
                        else
                        {
                            Canvas.SetTop(image, random.Next(0 - ((int)image.Height / 2), Core.GetPercentage((int)canvas.ActualHeight, boundry)));
                            Canvas.SetLeft(image, 0 - image.Width);
                        }
                    }
                }
            }
