    private void Rectangle_ManipulationCompleted_1(object sender, ManipulationCompletedEventArgs e)
    {
        if (e.FinalVelocities.LinearVelocity.X > 2000)
            {
                                   
                    if (ScrollStoryboard.GetCurrentState() != ClockState.Stopped)
                        ScrollStoryboard.Stop(); // ensure storyboard stopped after previous run  
                    AnimationH.SetValue(DoubleAnimation.FromProperty, scrollviewer.HorizontalOffset);
                    AnimationH.SetValue(DoubleAnimation.ToProperty, (double)vm.Position);
                    Storyboard.SetTarget(ScrollStoryboard, scrollviewer);
                    ScrollStoryboard.Begin();
                    
                
            }
    }
