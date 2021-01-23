         protected override void OnPaddingChanged(EventArgs e)
		{
			base.OnPaddingChanged(e);
			if (Padding.Left < 3)
			{
				base.Padding = new Padding(3, base.Padding.Top, base.Padding.Right, base.Padding.Bottom);
			}
			if (Padding.Top < 3)
			{
				base.Padding = new Padding(base.Padding.Left, 3, base.Padding.Right, base.Padding.Bottom);
			}
			if (Padding.Right < 3)
			{
				base.Padding = new Padding(base.Padding.Left, base.Padding.Top, 4, base.Padding.Bottom);
			}
			if (Padding.Bottom < 3)
			{
				base.Padding = new Padding(base.Padding.Left, base.Padding.Top, base.Padding.Right, 3);
			}
		}
