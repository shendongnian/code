    var storyboard = new Storyboard();
    var totalDuration = TimeSpan.Zero;
    for (...)
    {
        var rotation = new AxisAngleRotation3D(axis, angle);
        var transform = new RotateTransform3D(rotation, new Point3D(0, 0, 0));
        var duration = TimeSpan.FromMilliseconds(370);
        var animation = new DoubleAnimation(0, angle, duration);
        animation.BeginTime = totalDuration;
        totalDuration += duration;
        Storyboard.SetTarget(animation, rotation);
        Storyboard.SetTargetProperty(animation, new PropertyPath(AxisAngleRotation3D.AngleProperty));
        storyboard.Children.Add(animation);
    }
    storyboard.Begin();
