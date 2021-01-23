    void CreateLoadAnimationForRow(int row, int startTime)
        {
            foreach (var child in LayoutRoot.Children.Cast<FrameworkElement>().Where(x => Grid.GetRow(x) == row))
            {
                AddToStoryboard(child, startTime);
            }
        }
        void AddToStoryboard(FrameworkElement element, int startTime)
        {
            element.RenderTransform = new CompositeTransform();
            var doubleAnimation = new DoubleAnimation
            {
                From = -200,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromMilliseconds(startTime)
            };
            var objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames()
            {
                BeginTime = TimeSpan.FromMilliseconds(startTime + 10)
            };
            var discreteObjectKeyFrame = new DiscreteObjectKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)),
                Value = Visibility.Visible
            };
            objectAnimationUsingKeyFrames.KeyFrames.Add(discreteObjectKeyFrame);
            IEasingFunction easingFunction = new SineEase();
            easingFunction.Ease(2);
            doubleAnimation.EasingFunction = easingFunction;
            Storyboard.SetTarget(objectAnimationUsingKeyFrames, element);
            Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames, new PropertyPath("Visibility"));
            Storyboard.SetTarget(doubleAnimation, element);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(FrameworkElement.RenderTransform).(CompositeTransform.TranslateX)"));
            storyboardSlideIn.Children.Add(doubleAnimation);
            storyboardSlideIn.Children.Add(objectAnimationUsingKeyFrames);
        }
