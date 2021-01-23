     private void UIElement_OnStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            if (e.SystemGesture == SystemGesture.Tap)
            {
                if (e.IsDoubleTap(sender as IInputElement))
                {
                   // Do your stuff here
                }
            }
        }
