            private void UpdateUserInterface(double offset) {
            var thumbItem = Thumb as FrameworkElement;
            if ( _thumbStoryboard == null ) {
                // UpdateLayout Method is update the ActualWidth Properity of the UI Elements
                this.UpdateLayout();
                
                // Applying the CompositeTransform on "thumbItem" UI Element
                thumbItem.RenderTransform = _thumbTransform;
                // Setting the Render Transform Origin to be the Center of X and Y
                thumbItem.RenderTransformOrigin = new Point(0.5d, 0.5d);
                // Setting the target of the DoubleAnimation to be the Thumb CompositeTransform
                Storyboard.SetTarget(_thumbAnimation, _thumbTransform);
                // Setting the Targeted Properity of the DoubleAnimation to be The "TranslateX" Properity
                Storyboard.SetTargetProperty(_thumbAnimation, new PropertyPath("TranslateX"));
                // Used QuinticEase instead of ExponentialEase
                // and Added EaseOut to make the animation be more smoother.
                _thumbAnimation.EasingFunction = new QuinticEase(){ EasingMode = EasingMode.EaseOut };
                // Initializing the Storyboard
                _thumbStoryboard = new Storyboard();
                // Specifing the Duration of the DoubleAnimation not the StoryBoard
                _thumbAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                // Adding the DoubleAnimation to the Children of the Storyboard
                _thumbStoryboard.Children.Add(_thumbAnimation);
            }
            // Calculate the New Centered Position
            double newPos = offset - (thumbItem.ActualWidth / 2);
            // Set the New DoubleAnimation "To" Value, 
            // There is no need to set the "From" Value since it'll automatically continue from the current TranslateX Value
            _thumbAnimation.To = newPos;
            // Begin the animation.
            _thumbStoryboard.Begin();
        }
