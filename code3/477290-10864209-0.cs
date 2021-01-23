    TextBlock text = new TextBlock();
    text.Inlines.AddRange(
        new Inline[]
            {
                new Run("Foo "),
                new Run(string.Format("\"{0}\"", "qux")) {Foreground = Brushes.Red},
                new Run(" bar")
            });
    menu.Items.Insert(0, new MenuItem
    {
        Header = text
    }); 
