		internal int CountOccurrences(string haystack, string needle) {
			int n = 0, pos = 0;
			while((pos = haystack.IndexOf(needle, pos)) != -1) {
				n++;
				pos += needle.Length;
			}
			return n;
		}
		
		void ListBox1MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = (int)((CountOccurrences(((ListBox)sender).Items[e.Index].ToString(), "\n") + 1) * ((ListBox)sender).Font.GetHeight() + 2);
		}
		
		void ListBox1DrawItem(object sender, DrawItemEventArgs e)
		{
			string text = ((ListBox)sender).Items[e.Index].ToString();
			e.DrawBackground();
			using(Brush b = new SolidBrush(e.ForeColor)) e.Graphics.DrawString(text, e.Font, b, new RectangleF(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
			e.DrawFocusRectangle();
		}
