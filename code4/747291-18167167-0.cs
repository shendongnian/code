    SlideTransition slideTransition = new SlideTransition { Mode = SlideTransitionMode.SlideRightFadeOut };
    ITransition transition = slideTransition.GetTransition(textBlockSong);
    transition.Completed += delegate 
    { 
        transition.Stop(); 
        SlideTransition slideTransition2 = new SlideTransition { Mode = SlideTransitionMode.SlideRightFadeIn };
        ITransition transition2 = slideTransition2.GetTransition(textBlockSong);
        transition2.Completed += delegate { transition2.Stop(); };
        transition2.Begin();
    };
    transition.Begin();     
