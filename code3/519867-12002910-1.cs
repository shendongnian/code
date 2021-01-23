    var _messages = new ObservableCollection<Message>();
    for (int i = 0; i < 50; i++)
    {
        _messages.Add(new Message("12:40", "Teh very long string which should be wrapped. Pavel Durov gives WP7 Contest winners less money than he did for Android/iOS winners. FFFUUUUUUUUUUUUUU "));
    }
    this.ListBox.ItemsSource = _messages;
