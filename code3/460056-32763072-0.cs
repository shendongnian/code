    void restoreHyperlinks()
    {
        TextRange tr = new TextRange(_richTextBox.Document.ContentStart, _richTextBox.Document.ContentEnd);
        TextPointer tp = tr.Start;
        bool bFound = false;
        foreach (System.Text.RegularExpressions.Match match in UrlRegex.Matches(tr.Text))
        {
            if (tp == null)
                tp = tr.Start;
            bFound = false;
            while (tp != null && !bFound)
            {
                if (tp.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = tp.GetTextInRun(LogicalDirection.Forward);
                    int indexInRun = textRun.IndexOf(match.Value);
                    if (indexInRun > -1)
                    {
                        bFound = true;
                        Inline parent = tp.Parent as Inline;
                        while (parent != null && !(parent is Hyperlink))
                        {
                            parent = parent.Parent as Inline;
                        }
                        if (parent is Hyperlink)
                        {
                            Hyperlink hyperlink = (Hyperlink)parent;
                            if (isHyperlink(match.Value))
                            {
                                Uri uri = new Uri(match.Value, UriKind.RelativeOrAbsolute);
                                if (!uri.IsAbsoluteUri)
                                {
                                    uri = new Uri(@"http://" + match.Value, UriKind.Absolute);
                                }
                                if (uri != null)
                                {
                                    hyperlink.NavigateUri = uri;
                                    hyperlink.Click += Hyperlink_Click;
                                }
                            }
                        }
                   }
               
                }
                tp = tp.GetNextContextPosition(LogicalDirection.Forward);
            }
        }
    }
