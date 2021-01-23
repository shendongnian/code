    public static void Friend(Canvas canvas)
    {
        var random = new Random();
        foreach (var element in canvas.Children.OfType<Image>())
        {
            var elementName = Regex.Split(element.Name, "_");
            if (elementName[0] == "friend")
            {
                var slideDown = new DoubleAnimation
                {
                    From = Canvas.GetBottom(element),
                    To = Canvas.GetBottom(element) - element.Height,
                    Duration = new Duration(TimeSpan.FromSeconds(1))
                };
                slideDown.Completed += (sender, e) =>
                {
                    element.Source = Core.StreamImage(Wardrobe.Friends[Wardrobe.RandomFriend()]);
                    Canvas.SetLeft(element, random.Next(0, (int)(canvas.ActualWidth - element.Width)));
                    var slideUp = new DoubleAnimation
                    {
                        From = Canvas.GetBottom(element),
                        To = Canvas.GetBottom(element) + element.Height,
                        Duration = new Duration(TimeSpan.FromSeconds(1))
                    };
                    element.BeginAnimation(Canvas.BottomProperty, slideUp);
                };
                element.BeginAnimation(Canvas.BottomProperty, slideDown);
            }
        }
    }
