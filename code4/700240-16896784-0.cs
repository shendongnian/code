        private void RichTextColumns_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RichTextColumns control = sender as RichTextColumns;
            Point pTapped = e.GetPosition(e.OriginalSource as UIElement);
            TextPointer tp = null;
            if (e.OriginalSource is RichTextBlock) // tapped in the 1st column
            {
                tp = control.RichTextContent.GetPositionFromPoint(pTapped);
            }
            else if (e.OriginalSource is RichTextBlockOverflow) // tapped in an overflow column
            {
                tp = (e.OriginalSource as RichTextBlockOverflow).GetPositionFromPoint(pTapped);
            }
            if (tp != null)
            {
                // find out which DocVerse (inherits from Span) contains the Run that was tapped
                Run r = tp.Parent as Run;
                foreach (DocVerse v in control.Verses)
                { 
                    if (v.Inlines.Contains(r))
                    {
                        v.FontWeight = FontWeights.Bold;
                        Debug.WriteLine(v.VerseIndex);
                    }
                }
            }
        }
