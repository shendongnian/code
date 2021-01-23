    private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;
        Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
        if (ptrPt.Properties.IsLeftButtonPressed)
        {
            //Do stuff
        }
        if (ptrPt.Properties.IsRightButtonPressed)
        {
            //Do stuff
        }
    }
