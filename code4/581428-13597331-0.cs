    public static void Friend(Canvas canvas)
    {
        foreach (var element in canvas.Children.OfType<Image>())
        {
            var elementName = Regex.Split(element.Name, "_");
            if (elementName[0] == "friend")
            {
                var slideDown = new DoubleAnimation
                    {
                        From = Canvas.GetBottom(element),
                        To = Canvas.GetBottom(element) - element.Height,
                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                        AutoReverse = true
                    };
                slideDown.Completed += (sender, e) => Test(sender, e, element, canvas);
                element.BeginAnimation(Canvas.BottomProperty, slideDown);
            }
        }
    }
