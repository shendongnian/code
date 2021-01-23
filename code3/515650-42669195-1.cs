        public static void HighlightText(RichTextBox myRtb, string word, Color color)
        {
            if (word == string.Empty)
                return;
            var reg = new Regex(@"\b" + word + @"(\b|s\b)",RegexOptions.IgnoreCase);
            
            foreach (Match match in reg.Matches(myRtb.Text))
            {
                myRtb.Select(match.Index, match.Length);
                myRtb.SelectionColor = color;
            }
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }
