        /// <summary>
        /// Adds break to a TextBlock according to a specified tag
        /// </summary>
        /// <param name="text">The text containing the tags to break up</param>
        /// <param name="tb">The TextBlock we are assigning this text to</param>
        /// <param name="tag">The tag, eg <br> to use in adding breaks</param>
        /// <returns></returns>
        public string WordWrap(string text, TextBlock tb, string tag)
        {
            //get the amount of text that can fit into the textblock
            int len = (int)Math.Round((2 * tb.ActualWidth / tb.FontSize));
            string original = text.Replace(tag, "");
            string ret = "";
            while (original.Length > len)
            {
                //get index where tag occurred
                int i = text.IndexOf(tag);
                //get index where whitespace occurred
                int j = original.IndexOf(" ");
                //does tag occur earlier than whitespace, then let's use that index instead!
                if (j > i && j < len)
                    i = j;
                //if we usde index of whitespace, there is no need to hyphenate
                ret += (i == j) ? original.Substring(0, i) + "\n" : original.Substring(0, i) + "-\n";
                //if we used index of whitespace, then let's remove the whitespace
                original = (i == j) ? original.Substring(i + 1) : original.Substring(i);
                text = text.Substring(i + tag.Length);
            }
            return ret + original;
        }
