    public class NavigateAction : TargetedTriggerAction<Frame>
    {
        public static readonly DependencyProperty UriPathProperty =
            DependencyProperty.Register("UriPath", typeof(string), typeof(NavigateAction), null);
        public string UriPath
        {
            get { return (string)GetValue(UriPathProperty); }
            set { SetValue(UriPathProperty, value); }
        }
        protected override void Invoke(object parameter)
        {
            Target.Navigate(new Uri(UriPath, UriKind.RelativeOrAbsolute));
        }
    }
