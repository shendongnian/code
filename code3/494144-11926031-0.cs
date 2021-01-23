    private void bottomAppBar_Opened(object sender, object e)
        {
           this.LayoutRoot.Margin = new Thickness(0,0,0,90);
           this.MyImage.Stretch = Stretch.Fill;
        }
        private void bottomAppBar_Closed(object sender, object e)
        {
            this.LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
        }
