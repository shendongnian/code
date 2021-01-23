        var usercontrol1 = new Label();
        usercontrol1.Background = new SolidColorBrush(Colors.Red);
        usercontrol1.Content = "Hello";
        usercontrol1.Name = "UniqueName" + System.Guid.NewGuid().ToString("N");
        RegisterName(usercontrol1.Name, usercontrol1);
        StackPanel1.Children.Add(usercontrol1);
        // Create a DoubleAnimation to animate the width of the button.
        DoubleAnimation myDoubleAnimation = new DoubleAnimation();
        myDoubleAnimation.From = 0;
        myDoubleAnimation.To = 100;
        myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
        // Configure the animation to target the button's Width property.
        Storyboard.SetTargetName(myDoubleAnimation, usercontrol1.Name);
        Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.HeightProperty));
     // **Set the Target Object for the Animation.**
     Storyboard.SetTarget(myDoubleAnimation, usercontrol1);
        // Create a storyboard to contain the animation.
        Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
        myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);
        myWidthAnimatedButtonStoryboard.Begin(usercontrol1);
    }
