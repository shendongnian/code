    /// <summary>
    /// An application-defined function that processes messages sent to a window. The WNDPROC type
    /// defines a pointer to this callback function.
    /// </summary>
    /// <param name="hwnd">A handle to the window.</param>
    /// <param name="uMsg">The message.</param>
    /// <param name="wParam">Additional message information. The contents of this parameter depend on
    /// the value of the uMsg parameter.</param>
    /// <param name="lParam">Additional message information. The contents of this parameter depend on
    /// the value of the uMsg parameter.</param>
    /// <param name="handled">Reference to boolean value which indicates whether a message was handled.
    /// </param>
    /// <returns>The return value is the result of the message processing and depends on the message sent.
    /// </returns>
    private IntPtr WindowProc(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam, ref bool handled) {
        // BEGIN UNMANAGED WIN32
        switch((WinRT.Message)uMsg) {
            case WinRT.Message.WM_SIZE:
                switch((WinRT.Size)wParam) {
                    case WinRT.Size.SIZE_MAXIMIZED:
                        this.Left = this.Top = 0;
                        if(!this.IsMaximized)
                            this.IsMaximized = true;
                        this.UpdateChrome();
                        break;
                    case WinRT.Size.SIZE_RESTORED:
                        if(this.IsMaximized)
                            this.IsMaximized = false;
                        this.UpdateChrome();
                        break;
                }
                break;
            case WinRT.Message.WM_WINDOWPOSCHANGING:
                WinRT.WINDOWPOS windowPosition = (WinRT.WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WinRT.WINDOWPOS));
                Window handledWindow = (Window)HwndSource.FromHwnd(hwnd).RootVisual;
                if(handledWindow == null)
                    return IntPtr.Zero;
                bool hasChangedPosition = false;
                if(this.IsMaximized == true && (this.Left != 0 || this.Top != 0)) {
                    windowPosition.x = windowPosition.y = 0;
                    windowPosition.cx = (int)SystemParameters.WorkArea.Width;
                    windowPosition.cy = (int)SystemParameters.WorkArea.Height;
                    hasChangedPosition = true;
                    this.UpdateChrome();
                    this.UpdateGlowWindow();
                }
                if(!hasChangedPosition)
                    return IntPtr.Zero;
                Marshal.StructureToPtr(windowPosition, lParam, true);
                handled = true;
                break;
        }
        return IntPtr.Zero;
        // END UNMANAGED WIN32
    }
