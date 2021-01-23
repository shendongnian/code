    SlideTransition slideTransition = new SlideTransition();
    slideTransition.Mode = SlideTransitionMode.SlideRightFadeIn;
    ITransition transition = slideTransition.GetTransition(panorama_main);
    transition.Completed += delegate
    {
        transition.Stop();
    };
    PanoramaItem pItem = (PanoramaItem)panorama_main.Items[3];
    panorama_main.DefaultItem = pItem; 
    transition.Begin();
