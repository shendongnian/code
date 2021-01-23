    HwndSource wpfHandle = PresentationSource.FromVisual(this) as HwndSource;
    if (wpfHandle != null)
    {
        ElementHost host = System.Windows.Forms.Control.FromChildHandle(wpfHandle.Handle) as ElementHost;
        if (host != null)
        {
            Form1 form1 = host.Parent as Form1;
            if (form1 != null)
            {
                form1.samp();
            }
        }
    }
