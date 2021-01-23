    private void AnimateColor(string ellipseName, Color ellipseColor, string textBlockName, Color textBlockColor)
                {
                    EasingColorKeyFrame easingColorKeyFrameEllipseObj = new EasingColorKeyFrame();
                    easingColorKeyFrameEllipseObj.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(12));
                    easingColorKeyFrameEllipseObj.Value = ellipseColor;
        
                    ColorAnimationUsingKeyFrames colorAnimationUsingKeyFramesEllipseObj = new ColorAnimationUsingKeyFrames();
                    Storyboard.SetTargetName(colorAnimationUsingKeyFramesEllipseObj, ellipseName);
                    Storyboard.SetTargetProperty(
                        colorAnimationUsingKeyFramesEllipseObj, new PropertyPath("(Shape.Fill).(SolidColorBrush.Color)"));
                    colorAnimationUsingKeyFramesEllipseObj.KeyFrames.Add(easingColorKeyFrameEllipseObj);
        
                    EasingColorKeyFrame easingColorKeyFrameTextBlockObj = new EasingColorKeyFrame();
                    easingColorKeyFrameTextBlockObj.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(12));
                    easingColorKeyFrameTextBlockObj.Value = textBlockColor;
        
                    ColorAnimationUsingKeyFrames colorAnimationUsingKeyFramesTextBlockObj = new ColorAnimationUsingKeyFrames();
                    Storyboard.SetTargetName(colorAnimationUsingKeyFramesTextBlockObj, textBlockName);
                    Storyboard.SetTargetProperty(
                        colorAnimationUsingKeyFramesTextBlockObj, new PropertyPath("(TextElement.Background).(SolidColorBrush.Color)"));
                    colorAnimationUsingKeyFramesTextBlockObj.KeyFrames.Add(easingColorKeyFrameTextBlockObj);
        
        
                    Storyboard storyboard = new Storyboard();
        
                    storyboard.Children.Add(colorAnimationUsingKeyFramesEllipseObj);
                    storyboard.Children.Add(colorAnimationUsingKeyFramesTextBlockObj);
        
                    storyboard.Begin(this, true);
                }
