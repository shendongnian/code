    public class SelectableTextBlock : TextBox
    {
        public SelectableTextBlock()
        {
            AddHandler(KeyDownEvent, new RoutedEventHandler(HandleHandledKeyDown), true);
        }
        public void HandleHandledKeyDown(object sender, RoutedEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if(ke != null && ke.Key == Key.Space)
            {
                ke.Handled = false;
            }
        }
    }
