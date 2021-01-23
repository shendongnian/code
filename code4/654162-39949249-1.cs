        static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as HighlightableTextBlock;
            var text = textBlock.Text;
            var source = textBlock.HighlightSource;
            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(text))
            {
                var index = text.IndexOf(source);
                if (index >= 0)
                {
                    var start = text.Substring(0, index);
                    var match = text.Substring(index, source.Length);
                    var end = text.Substring(index + source.Length);
                    textBlock.Inlines.Clear();
                    textBlock.Inlines.Add(new Run(start));
                    textBlock.Inlines.Add(new Run(match) { Foreground = Brushes.Red });
                    textBlock.Inlines.Add(new Run(end));
                }
            }
        }
