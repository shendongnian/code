        #region navigation
        public enum PanoramaItem
        {
            None = -1, Mag, Scan, Account, Lists, More, Help
        }
        public void PanoramaNavigateTo(PanoramaItem item)
        {
            bool left = (int)item > panorama.SelectedIndex;
            SlideTransition slideTransition = new SlideTransition();
            slideTransition.Mode = left ? SlideTransitionMode.SlideLeftFadeOut : SlideTransitionMode.SlideRightFadeOut;
            ITransition transition = slideTransition.GetTransition(panorama);
            transition.Completed += delegate
            {
                transition.Stop();
                SlideTransition slideTransitionIn = new SlideTransition();
                slideTransitionIn.Mode = left ? SlideTransitionMode.SlideLeftFadeIn : SlideTransitionMode.SlideRightFadeIn;
                ITransition transitionIn = slideTransitionIn.GetTransition(panorama);
                transitionIn.Completed += delegate { transitionIn.Stop(); };
                panorama.SetValue(Panorama.SelectedItemProperty, panorama.Items[(int)item]);
                Panorama temp = panorama;
                LayoutRoot.Children.Remove(panorama);
                LayoutRoot.Children.Add(temp);
                LayoutRoot.UpdateLayout();
                transitionIn.Begin();
            };
            transition.Begin();
        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (panorama.DefaultItem != panorama.Items[(int)PanoramaItem.Mag])
            {
                PanoramaNavigateTo(PanoramaItem.Mag);
                e.Cancel = true;
            }
        }
        #endregion
