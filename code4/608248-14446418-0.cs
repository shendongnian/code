        private void FindHRules()
        {
            foreach (Paragraph block in rtf.Document.Blocks.OfType<Paragraph>())
            {
                var inlines = block.Inlines.ToList();
                for(int i = 0; i<inlines.Count; i++)
                {
                    var inline = inlines[i];
                    TextRange r = new TextRange(inline.ContentStart, inline.ContentEnd);
                    if (r.Text.StartsWith("--"))
                    {
                        Line l = new Line { Stretch = Stretch.Fill, Stroke = Brushes.DarkBlue, X2 = 1 };
                        block.Inlines.InsertAfter(inline, new InlineUIContainer(l));
                        block.Inlines.Remove(inline);
                    }
                }
            }
        }
