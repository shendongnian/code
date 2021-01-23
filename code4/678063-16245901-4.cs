	public Form1()
	{
		InitializeComponent();
		UsbNotification.RegisterUsbDeviceNotification(this.Handle);
	}
	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
			if (m.Msg == UsbNotification.WmDevicechange)
		{
			switch ((int)m.WParam)
			{
				case UsbNotification.DbtDeviceremovecomplete:
					Usb_DeviceRemoved(); // this is where you do your magic
					break;
				case UsbNotification.DbtDevicearrival:
					Usb_DeviceAdded(); // this is where you do your magic
					break;
			}
		}
	}	
