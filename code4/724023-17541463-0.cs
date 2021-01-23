    private void PhoneApplicationPage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //string to save coordinates of tap
            TapCoordinatesXBegin = e.GetPosition(LayoutRoot).X.ToString();
            TapCoordinatesYBegin = e.GetPosition(LayoutRoot).Y.ToString();
        }
