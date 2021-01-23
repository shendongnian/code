        private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
         if (ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
         {
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(Target);
            if (ptrPt.Properties.IsLeftButtonPressed)
            {
            e.Handled = true;
            }
         }
        }
