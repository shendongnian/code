    public static void FadeOut(UIElement target, int milliseconds)
        {
           DoubleAnimation da = new DoubleAnimation();
           da.From = target.Opacity;
           da.To = 0.0;
           da.Duration = TimeSpan.FromMilliseconds(milliseconds);
           da.AutoReverse = false;
           System.Windows.Media.Animation.Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
           System.Windows.Media.Animation.Storyboard.SetTarget(da, target);
           System.Windows.Media.Animation.Storyboard sb = new System.Windows.Media.Animation.Storyboard();
           sb.Children.Add(da);
          
           sb.Begin();
       }
