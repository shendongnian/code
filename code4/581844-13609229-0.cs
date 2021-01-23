    public Size GetDefaultSize(Control ctrl)
	{
		PropertyInfo pi = ctrl.GetType().GetProperty("DefaultSize", BindingFlags.NonPublic | BindingFlags.Instance);
		return (Size)pi.GetValue(ctrl, null);
	}
    myCtrl.Size = GetDefaultSize(myCtrl);
