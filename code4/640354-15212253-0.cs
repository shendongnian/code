    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // pause
            var _Media = GetMediaElement(sender as Button);
            _Media.Pause();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // play
            var _Media = GetMediaElement(sender as Button);
            _Media.Play();
        }
        MediaElement GetMediaElement(Button button)
        {
            var _Parent = button.Parent as Grid;
            var _GrandParent = _Parent.Parent as Grid;
            return _GrandParent.Children.First() as MediaElement;
        }
        private void FlipView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var _FlipView = sender as FlipView;
            foreach (var item in _FlipView.Items)
            {
                var _Container = _FlipView.ItemContainerGenerator.ContainerFromItem(item);
                var _Children = AllChildren(_Container);
                foreach (var media in _Children)
                    media.Pause();
            }
        }
        public List<MediaElement> AllChildren(DependencyObject parent)
        {
            if (parent == null)
                return (new MediaElement[] { }).ToList();
            var _List = new List<MediaElement> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is MediaElement)
                    _List.Add(_Child as MediaElement);
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }
    }
