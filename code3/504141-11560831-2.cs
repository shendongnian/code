    var usercontrol1 = getMyNewControl();
    usercontrol1.Name= "UniqueName" + System.Guid.NewGuid().ToString("N");
    StackPanel1.children.Add(usercontrol1);
    // Create a DoubleAnimation to animate the width of the button.
    DoubleAnimation myDoubleAnimation = new DoubleAnimation();
    myDoubleAnimation.From = 0;
    myDoubleAnimation.To = 100;
    myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));          
    // Configure the animation to target the button's Width property.
    Storyboard.SetTargetName(myDoubleAnimation, usercontrol1.Name); 
    Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.HeightProperty));
    // Create a storyboard to contain the animation.
    Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
    myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);
    myWidthAnimatedButtonStoryboard.Begin(usercontrol1);
