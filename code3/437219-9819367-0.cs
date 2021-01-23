    private Point _ownerLocation;
    private void OnOwnerLocationChanged(object sender, EventArgs e)
		{
			Console.WriteLine("OnOwnerLocationChanged");
            _ownerLocation = new Point(Owner.Top, Owner.Left);
			SetLocationToOwner();
		}
    private void SetLocationToOwner()
		{
			if (IsVisible && (Owner != null))
			{
				Console.WriteLine("T: {0}; L: {1}; W: {2}; H: {3}", Owner.Top, Owner.Left, Owner.ActualWidth, Owner.ActualHeight);
                Top = _ownerLocation.X + ((Owner.ActualHeight - ActualHeight) / 2);
                Left = _ownerLocation.Y + ((Owner.ActualWidth - ActualWidth) / 2);
			}
		}
