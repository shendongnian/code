    DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
    animation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("(0).(1)", UIElement.RenderTransformProperty, RotateTransform.AngleProperty));
    var totalAnimationLength = 1600; // Milliseconds
    double repeatInterval = 1600;// Milliseconds
    if (repeatInterval < totalAnimationLength) repeatInterval = totalAnimationLength; // Can't be less than zero and pointless to be less than total length 
    animation.Duration = new Duration(TimeSpan.FromMilliseconds(repeatInterval));
    animation.RepeatBehavior = RepeatBehavior.Forever; // assuming this was intended from having a repeat interval?
    animation.KeyFrames.Add(new LinearDoubleKeyFrame(30, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(totalAnimationLength * 0.25))));
    animation.KeyFrames.Add(new LinearDoubleKeyFrame(-30, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(totalAnimationLength * 0.75))));
    animation.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(totalAnimationLength))));
