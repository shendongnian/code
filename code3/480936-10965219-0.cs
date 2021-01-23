    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
        Button2.Content = new TextHolder("Button with string");
        Button3.Content = 16;
    }
    public class TextHolder
    {
        private readonly string _text;
        public TextHolder(string text)
        {
            _text = text;
        }
        public override string ToString()
        {
            return _text;
        }
    }
