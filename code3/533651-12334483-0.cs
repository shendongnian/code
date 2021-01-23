    var sb = new Storyboard { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300)) };
    var aniWidth = new DoubleAnimationUsingKeyFrames();
    var aniHeight = new DoubleAnimationUsingKeyFrames();
    aniWidth.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300));
    aniHeight.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 150));
    aniHeight.KeyFrames.Add(new EasingDoubleKeyFrame(target.ActualHeight, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 00))));
    aniHeight.KeyFrames.Add(new EasingDoubleKeyFrame(newHeight, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 150))));
    aniWidth.KeyFrames.Add(new EasingDoubleKeyFrame(target.ActualWidth, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 150))));
    aniWidth.KeyFrames.Add(new EasingDoubleKeyFrame(newWidth, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 300))));
