    public static string WrapText(this string text, double pixels, string fontFamily, float emSize)
        {
            string[] originalLines = text.Split(new[] { " " }, StringSplitOptions.None);
            var wrapBuilder = new StringBuilder();
            
            double actualWidth = 0;
            foreach (var item in originalLines)
            {
                var formatted = new FormattedText(
                    item,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(fontFamily),
                    emSize,
                    Brushes.Black);
                actualWidth += formatted.Width;
                if (actualWidth > pixels)
                {
                    wrapBuilder.Append(Environment.NewLine);
                    actualWidth = 0;
                }
                wrapBuilder.Append(item + " ");
            }
            return wrapBuilder.ToString();
        }
