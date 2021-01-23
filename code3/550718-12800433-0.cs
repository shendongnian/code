    //Quit if both hands above head
    if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.Head].Position.Y &&
        skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.Head].Position.Y &&
        !pause)
    {
        pause = true;
        quit();
    }
    else
    {
        pause = false;
    }
    ...
    private void quit()
    {
        MessageBoxButton button = MessageBoxButton.YesNo;
        MessageBoxImage image = MessageBoxImage.Warning;
        MessageBoxResult result = MessageBox.Show("Are you sure you want to quit?", "Close V'Me :(", button, image);
        if (result == MessageBoxResult.Yes) window.Close();
        else if (result == MessageBoxResult.No)
        {
            pause = false;
        }
    }
