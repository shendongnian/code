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
					SizeF space = e.Graphics.MeasureString(" ", font);
					float f = s.Width + space.Width;
					e.Graphics.DrawString(texts[1], font, brush, e.Bounds.Left + (int)f, e.Bounds.Top);
				}
			}
		}
