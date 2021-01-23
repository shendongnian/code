    // get any gestures that are ready.
    while (TouchPanel.IsGestureAvailable)
    {
        GestureSample gs = TouchPanel.ReadGesture();
        switch (gs.GestureType)
        {
            case GestureType.VerticalDrag:
                // move the poem screen vertically by the drag delta
                // amount.
                poem.offset.Y -= gs.Delta.Y;
                break;
    
            case GestureType.Flick:
                // add velocity to the poem screen (only interested in
                // changes to Y velocity).
                poem.velocity.Y += gs.Delta.Y;
                break;
        }
    }
