	class HighLighting
	{
		public void HighlightText(RichTextBox rtb, string word)
		{
			int s_start = rtb.SelectionStart, startIndex = 0, index;
			while ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
			{
				rtb.Select(index, word.Length);
				rtb.SelectionBackColor = Color.Yellow;
				startIndex = index + word.Length;
			}
			rtb.SelectionStart = s_start;
			rtb.SelectionLength = 0;
			rtb.SelectionColor = Color.Black;
			rtb.ScrollToCaret();
		}
	}
