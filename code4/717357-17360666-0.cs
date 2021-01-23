    if (TargetProperty == PlaneProjection.RotationYProperty)
    {
        // Do some code
        projection = control.Projection as PlaneProjection;
        Storyboard.SetTarget(doubleAnimation, projection);
    }
    else if (TargetProperty == Control.OpacityProperty)
    {
        Storyboard.SetTarget(doubleAnimation, control);
    }
