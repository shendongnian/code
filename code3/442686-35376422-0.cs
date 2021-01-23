	public class EnhancedButton : Button
	{
		private bool _rightButtonDown = false;
		public EnhancedButton()
		{
			MouseRightButtonDown += RightClickButton_MouseRightButtonDown;
			MouseRightButtonUp   += RightClickButton_MouseRightButtonUp;
		}
		#region RightClick Event
			public event RoutedEventHandler RightClick;
			protected virtual void OnRightClick(MouseButtonEventArgs e)
			{
				RightClick?.Invoke(this, e);
			}
		#endregion RightClick Event
		#region Event Handlers
			private void RightClickButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
			{
				IsPressed = true;
				_rightButtonDown = true;
				CaptureMouse();
				if(ClickMode == ClickMode.Press)
					OnRightClick(e);
			}
			private void RightClickButton_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
			{
				if(!_rightButtonDown)
					return;
				ReleaseMouseCapture();
				IsPressed = false;
				if(IsMouseOver && ClickMode == ClickMode.Release)
					OnRightClick(e);
				_rightButtonDown = false;
			}
		#endregion Event Handlers
		#region Overrides
			protected override void OnMouseMove(MouseEventArgs e)
			{
				base.OnMouseMove(e);
				if(!_rightButtonDown)
					return;
				bool isInside = false;
				VisualTreeHelper.HitTest(this, d =>
				{
					if (d == this)
						isInside = true;
					return HitTestFilterBehavior.Stop;
				},
				ht => HitTestResultBehavior.Stop,
				new PointHitTestParameters(e.GetPosition(this)));
				IsPressed = isInside;
			}
		#endregion Overrides
	}
