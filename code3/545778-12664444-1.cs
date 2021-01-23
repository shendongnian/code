    [DllImport("user32.dll")]
	public static extern void keybd_event(byte bVk,	byte bScan,	uint dwFlags, uint dwExtraInfo);
	public void SendKey(Keys keys){
		foreach(Keys key in Enum.GetValues(typeof(Keys)))
			if(keys.HasFlag(key))
				keybd_event((byte)key, 0, 0, 0); //press key
		foreach(Keys key in Enum.GetValues(typeof(Keys)))
			if(keys.HasFlag(key))
				keybd_event((byte)key, 0, 0x2, 0); // release key
	}
