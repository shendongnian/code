    // [...]
    new UIPermission(UIPermissionWindow.AllWindows).Demand();
    int width = blockRegionSize.Width;
    int height = blockRegionSize.Height;
    using (DeviceContext deviceContext = DeviceContext.FromHwnd(IntPtr.Zero))
	{
		HandleRef hSrcDC = new HandleRef(null, deviceContext.Hdc);
		HandleRef hDC = new HandleRef(null, this.GetHdc());
		try
		{
			if (SafeNativeMethods.BitBlt(hDC, destinationX, destinationY, width, height, hSrcDC, sourceX, sourceY, (int)copyPixelOperation) == 0)
			{
				throw new Win32Exception();
			}
		}
		finally
		{
			this.ReleaseHdc();
		}
	}
