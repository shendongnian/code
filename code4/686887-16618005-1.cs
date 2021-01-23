	public class ManuallyScrollableContainer : Control
	{
		public ManuallyScrollableContainer()
		{
			InitializeControls();
		}
		private class UpdatingHScrollBar : HScrollBar
		{
			protected override void OnValueChanged(EventArgs e)
			{
				base.OnValueChanged(e);
				// setting the scroll position programmatically shall raise Scroll
				this.OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, this.Value));
			}
		}
		private class UpdatingVScrollBar : VScrollBar
		{
			protected override void OnValueChanged(EventArgs e)
			{
				base.OnValueChanged(e);
				// setting the scroll position programmatically shall raise Scroll
				this.OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, this.Value));
			}
		}
		private ScrollBar shScrollBar;
		private ScrollBar svScrollBar;
		public ScrollBar HScrollBar
		{
			get { return this.shScrollBar; }
		}
		public ScrollBar VScrollBar
		{
			get { return this.svScrollBar; }
		}
		private void InitializeControls()
		{
			this.shScrollBar = new UpdatingHScrollBar();
			this.shScrollBar.Top = this.Height - this.shScrollBar.Height;
			this.shScrollBar.Left = 0;
			this.shScrollBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.svScrollBar = new UpdatingVScrollBar();
			this.svScrollBar.Top = 0;
			this.svScrollBar.Left = this.Width - this.svScrollBar.Width;
			this.svScrollBar.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			this.shScrollBar.Width = this.Width - this.svScrollBar.Width;
			this.svScrollBar.Height = this.Height - this.shScrollBar.Height;
			this.Controls.Add(this.shScrollBar);
			this.Controls.Add(this.svScrollBar);
			this.shScrollBar.Scroll += this.HandleScrollBarScroll;
			this.svScrollBar.Scroll += this.HandleScrollBarScroll;
		}
		private Control _content;
        /// <summary>
        /// Specifies the control that should be displayed in this container.
        /// </summary>
		public Control Content
		{
			get { return this._content; }
			set
			{
				if (_content != value)
				{
					RemoveContent();
					this._content = value;
					AddContent();
				}
			}
		}
		private void AddContent()
		{
			if (this.Content != null)
			{
				this.Content.Left = 0;
				this.Content.Top = 0;
				this.Content.Width = this.Width - this.svScrollBar.Width;
				this.Content.Height = this.Height - this.shScrollBar.Height;
				this.Content.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
				this.Controls.Add(this.Content);
				CalculateMinMax();
			}
		}
		private void RemoveContent()
		{
			if (this.Content != null)
			{
				this.Controls.Remove(this.Content);
			}
		}
		protected override void OnParentChanged(EventArgs e)
		{
            // mouse wheel events only arrive at the parent control
			if (this.Parent != null)
			{
				this.Parent.MouseWheel -= this.HandleMouseWheel;
			}
			base.OnParentChanged(e);
			if (this.Parent != null)
			{
				this.Parent.MouseWheel += this.HandleMouseWheel;
			}
		}
		private void HandleMouseWheel(object sender, MouseEventArgs e)
		{
			this.HandleMouseWheel(e);
		}
		/// <summary>
		/// Specifies how the control reacts to mouse wheel events.
		/// Can be overridden to adjust the scroll speed with the mouse wheel.
		/// </summary>
		protected virtual void HandleMouseWheel(MouseEventArgs e)
		{
			// The scroll difference is calculated so that with the default system setting
			// of 3 lines per scroll incremenet,
			// one scroll will offset the scroll bar value by LargeChange / 4
			// i.e. a quarter of the thumb size
			ScrollBar scrollBar;
			if ((Control.ModifierKeys & Keys.Shift) != 0)
			{
				scrollBar = this.HScrollBar;
			}
			else
			{
				scrollBar = this.VScrollBar;
			}
			var minimum = 0;
			var maximum = scrollBar.Maximum - scrollBar.LargeChange;
			if (maximum <= 0)
			{
				// happens when the entire area is visible
				return;
			}
			var value = scrollBar.Value - (int)(e.Delta * scrollBar.LargeChange / (120.0 * 12.0 / SystemInformation.MouseWheelScrollLines));
			scrollBar.Value = Math.Min(Math.Max(value, minimum), maximum);
		}
		public event ScrollEventHandler Scroll;
		protected virtual void OnScroll(ScrollEventArgs e)
		{
			var handler = this.Scroll;
			if (handler != null)
			{
				handler(this, e);
			}
		}
		/// <summary>
		/// Event handler for the Scroll event of either scroll bar.
		/// </summary>
		private void HandleScrollBarScroll(object sender, ScrollEventArgs e)
		{
			OnScroll(e);
			if (this.Content != null)
			{
				this.Content.AutoScrollOffset = new System.Drawing.Point(-this.HScrollBar.Value, -this.VScrollBar.Value);
				this.Content.Invalidate();
			}
		}
		private int _totalContentWidth;
		public int TotalContentWidth
		{
			get { return _totalContentWidth; }
			set
			{
				if (_totalContentWidth != value)
				{
					_totalContentWidth = value;
					CalculateMinMax();
				}
			}
		}
		private int _totalContentHeight;
		public int TotalContentHeight
		{
			get { return _totalContentHeight; }
			set
			{
				if (_totalContentHeight != value)
				{
					_totalContentHeight = value;
					CalculateMinMax();
				}
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			CalculateMinMax();
		}
		private void CalculateMinMax()
		{
			if (this.Content != null)
			{
				// Reduced formula according to
				// http://msdn.microsoft.com/en-us/library/system.windows.forms.scrollbar.maximum.aspx
				// Note: The original formula is bogus.
				// According to the article, LargeChange has to be known in order to calculate Maximum,
				// however, that is not always possible because LargeChange cannot exceed Maximum.
				// If (LargeChange) == (1 * visible part of control), the formula can be reduced to:
				if (this.TotalContentWidth > this.Content.Width)
				{
					this.shScrollBar.Enabled = true;
					this.shScrollBar.Maximum = this.TotalContentWidth;
				}
				else
				{
					this.shScrollBar.Enabled = false;
				}
				if (this.TotalContentHeight > this.Content.Height)
				{
					this.svScrollBar.Enabled = true;
					this.svScrollBar.Maximum = this.TotalContentHeight;
				}
				else
				{
					this.svScrollBar.Enabled = false;
				}
				// this must be set after the maximum is determined
				this.shScrollBar.LargeChange = this.shScrollBar.Width;
				this.shScrollBar.SmallChange = this.shScrollBar.LargeChange / 10;
				this.svScrollBar.LargeChange = this.svScrollBar.Height;
				this.svScrollBar.SmallChange = this.svScrollBar.LargeChange / 10;
			}
		}
	}
