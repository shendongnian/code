    var gesture = default(GestureSample);
    while (TouchPanel.IsGestureAvailable)
    {
        gesture = TouchPanel.ReadGesture();
        if (gesture.GestureType == GestureType.VerticalDrag)
        {
            if (gesture.Delta.Y < 0)
                return new RotateLeftCommand(_gameController);
            if (gesture.Delta.Y > 0)
                return new RotateRightCommand(_gameController);
        }
        if (gesture.GestureType == GestureType.HorizontalDrag)
        {
            if (gesture.Delta.X < 0)
                return new RotateLeftCommand(_gameController);
            if (gesture.Delta.X > 0)
                return new RotateRightCommand(_gameController);
        }
    }
