     var slideDown = new DoubleAnimation { From = 100, To = 200, Duration = new Duration(TimeSpan.FromSeconds(5)), AutoReverse = true };
     var slideLeft = new DoubleAnimation { From = 100, To = 200, BeginTime = TimeSpan.FromSeconds(5), Duration = new Duration(TimeSpan.FromSeconds(5)), AutoReverse = true };
    
     Storyboard storyBoard = new Storyboard();
     storyBoard.Children.Add(slideDown);
     storyBoard.Children.Add(slideLeft);
     Storyboard.SetTargetName(slideDown, myCanvas.Name);
     Storyboard.SetTargetName(slideLeft, myCanvas.Name);
     Storyboard.SetTargetProperty(slideLeft, new PropertyPath(Canvas.LeftProperty));
     Storyboard.SetTargetProperty(slideDown, new PropertyPath(Canvas.TopProperty));
    
     myCanvas.BeginStoryboard(storyBoard);
