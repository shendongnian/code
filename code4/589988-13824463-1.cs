		private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			string[] texts = e.Node.Text.Split();
			using (Font font = new Font(this.Font, FontStyle.Regular))
			{
				using (Brush brush = new SolidBrush(Color.Red))
				{
					e.Graphics.DrawString(texts[0], font, brush, e.Bounds.Left, e.Bounds.Top);
				}
				using (Brush brush = new SolidBrush(Color.Blue))
				{
					SizeF s = e.Graphics.MeasureString(texts[0], font);
					e.Graphics.DrawString(texts[1], font, brush, e.Bounds.Left + (int)s.Width, e.Bounds.Top);
				}
			}
		}
