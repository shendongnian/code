    private void StartTransition()
    {
        RotateTransition rotatetransition = new RotateTransition();
        rotatetransition.Mode = RotateTransitionMode.In90Clockwise;
     
        PhoneApplicationPage phoneApplicationPage =
        (PhoneApplicationPage)(((PhoneApplicationFrame)Application.Current.RootVisual)).Content;
     
        ITransition transition = rotatetransition.GetTransition(phoneApplicationPage);
        transition.Completed += delegate
        { 
            transition.Stop(); 
        };
        transition.Begin();
    }
