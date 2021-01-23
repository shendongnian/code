	/// <summary>
	/// Handles the DragDelta event of the ResizeLeft control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragDeltaEventArgs"/> instance containing the event data.</param>
	private void ResizeLeft_DragDelta(object sender, DragDeltaEventArgs e)
	{
		if (ActualWidth - e.HorizontalChange < MinWidth)
			return;
		double newLeft = e.HorizontalChange;
		if (Position.X + newLeft < 0)
			newLeft = 0 - Position.X;
		Width = ActualWidth - newLeft;
		Position = new Point(Position.X + newLeft, Position.Y);
		if (sender != null)
			Container.InvalidateSize();
	}
	/// <summary>
	/// Handles the DragDelta event of the ResizeTop control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragDeltaEventArgs"/> instance containing the event data.</param>
	private void ResizeTop_DragDelta(object sender, DragDeltaEventArgs e)
	{
		if (ActualHeight - e.VerticalChange < MinHeight)
			return;
		double newTop = e.VerticalChange;
		if (Position.Y + newTop < 0)
			newTop = 0 - Position.Y;
		Height = ActualHeight - newTop;
		Position = new Point(Position.X, Position.Y + newTop);
		if (sender != null)
			Container.InvalidateSize();
	}
	/// <summary>
	/// Handles the DragDelta event of the ResizeRight control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragDeltaEventArgs"/> instance containing the event data.</param>
	private void ResizeRight_DragDelta(object sender, DragDeltaEventArgs e)
	{
		if (ActualWidth + e.HorizontalChange < MinWidth)
			return;
		Width = ActualWidth + e.HorizontalChange;
		if (sender != null)
			Container.InvalidateSize();
	}
	/// <summary>
	/// Handles the DragDelta event of the ResizeBottom control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragDeltaEventArgs"/> instance containing the event data.</param>
	private void ResizeBottom_DragDelta(object sender, DragDeltaEventArgs e)
	{
		if (ActualHeight + e.VerticalChange < MinHeight)
			return;
		Height = ActualHeight + e.VerticalChange;
		if (sender != null)
			Container.InvalidateSize();
	}
