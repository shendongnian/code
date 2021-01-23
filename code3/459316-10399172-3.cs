		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			ForAllSubviewUIControlsOfType<UILabel>((label, depth) => {
				if ( /*label.Superview is UIView && label.Superview.Superview is UITableView*/ depth == 1 )
				{
					label.TextColor = UIColor.Black;
				}
			});
		}
