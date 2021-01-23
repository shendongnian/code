    // Create a red rectangle that will be the target 
    Rectangle myRectangle = new Rectangle();
    myRectangle.Width = 200;
    myRectangle.Height = 200;
    Color myColor = Color.FromArgb(255, 255, 0, 0);
    SolidColorBrush myBrush = new SolidColorBrush();
    myBrush.Color = myColor;
    myRectangle.Fill = myBrush;
    // Add the rectangle to the tree.
    LayoutRoot.Children.Add(myRectangle);
    // Create a duration of 2 seconds.
    Duration duration = new Duration(TimeSpan.FromSeconds(2));
    // Create two DoubleAnimations and set their properties.
    DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
    DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
    myDoubleAnimation1.Duration = duration;
    myDoubleAnimation2.Duration = duration;
    Storyboard sb = new Storyboard();
    sb.Duration = duration;
    sb.Children.Add(myDoubleAnimation1);
    sb.Children.Add(myDoubleAnimation2);
    Storyboard.SetTarget(myDoubleAnimation1, myRectangle);
    Storyboard.SetTarget(myDoubleAnimation2, myRectangle);
    // Set the attached properties of Canvas.Left and Canvas.Top
    // to be the target properties of the two respective DoubleAnimations.
    Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath("(Canvas.Left)"));
    Storyboard.SetTargetProperty(myDoubleAnimation2, new PropertyPath("(Canvas.Top)"));
    myDoubleAnimation1.To = 200;
    myDoubleAnimation2.To = 200;
    // Make the Storyboard a resource.
    LayoutRoot.Resources.Add("unique_id", sb);
    // Begin the animation.
    sb.Begin();
