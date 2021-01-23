	[DllImport("User32.dll")]
	private static extern bool RegisterHotKey(
		[In] IntPtr hWnd,
		[In] int id,
		[In] uint fsModifiers,
		[In] uint vk);
	[DllImport("User32.dll")]
	private static extern bool UnregisterHotKey(
		[In] IntPtr hWnd,
		[In] int id);
	private HwndSource _source;
	private const int HOTKEY_ID = 9000;
	protected override void OnSourceInitialized(EventArgs e)
	{
		base.OnSourceInitialized(e);
		var helper = new WindowInteropHelper(this);
		_source = HwndSource.FromHwnd(helper.Handle);
		_source.AddHook(HwndHook);
		RegisterHotKey();
	}
	protected override void OnClosed(EventArgs e)
	{
		_source.RemoveHook(HwndHook);
		_source = null;
		UnregisterHotKey();
		base.OnClosed(e);
	}
	private void RegisterHotKey()
	{
		var helper = new WindowInteropHelper(this);
		const uint VK_F10 = 0x79;
		const uint MOD_CTRL = 0x0002;
		if(!RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_CTRL, VK_F10))
		{
			// handle error
		}
	}
	private void UnregisterHotKey()
	{
		var helper = new WindowInteropHelper(this);
		UnregisterHotKey(helper.Handle, HOTKEY_ID);
	}
	private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		const int WM_HOTKEY = 0x0312;
		switch(msg)
		{
			case WM_HOTKEY:
				switch(wParam.ToInt32())
				{
					case HOTKEY_ID:
						OnHotKeyPressed();
						handled = true;
						break;
				}
				break;
		}
		return IntPtr.Zero;
	}
	private void OnHotKeyPressed()
	{
		// do stuff
	}
