    #region IMessageFilter implementation
    /// <summary> Redirect WM_MouseWheel messages to window under mouse.</summary>
		/// <remarks>Redirect WM_MouseWheel messages to window under mouse (rather than 
    /// that with focus) with adjusted delta.
    /// <see cref="http://www.flounder.com/virtual_screen_coordinates.htm"/>
    /// Dont forget to add this to constructor:
    /// 			Application.AddMessageFilter(this);
    ///</remarks>
		/// <param name="m">The Windows Message to filter and/or process.</param>
		/// <returns>Success (true) or failure (false) to OS.</returns>
		[System.Security.Permissions.PermissionSetAttribute(
			System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		bool IMessageFilter.PreFilterMessage(ref Message m) {
			// Determine window and control at these coordinates.
      //var pos   = WindowsMouseInput.GetPointLParam(m.LParam);
			var hWnd  = WindowFromPoint( WindowsMouseInput.GetPointLParam(m.LParam) );
			var ctl	  = Control.FromHandle(hWnd);
      if (hWnd != IntPtr.Zero  &&  hWnd != m.HWnd  &&  ctl != null) {
        switch(m.Msg) {
          default:  return false;
          case (int)WM.MOUSEWHEEL:
            DebugTracing.Trace(TraceFlag.ScrollEvents, true," - {0}.WM.MouseWheel: {1}", 
                                                        Host.Name, ((WM)m.Msg).ToString()); 
            if (ctl is MapPanel) {
              var keyState	  = WindowsMouseInput.GetKeyStateWParam(m.WParam);
              var mult			  = keyState.HasFlag(MouseKeys.Control) ? 5 : 1;
              keyState			  = keyState &= ~MouseKeys.Control;
              var wheelDelta	= WindowsMouseInput.WheelDelta(m.WParam);
              // forward delta of +/- 30 instead of +/- 120; 30/120 == 1/4
              var newWparam	  = WindowsMouseInput.WParam((Int16)(mult*wheelDelta/4), keyState);
              SendMessage(hWnd, m.Msg, newWparam, m.LParam);
              return true;
            } else if (ctl is MapFormOverview) {
              var keyState	  = WindowsMouseInput.GetKeyStateWParam(m.WParam);
              var wheelDelta	=  WindowsMouseInput.WheelDelta(m.WParam);
              // forward delta of +/- 54 instead of +/- 120
              // 54 = 3 * 18 (default point height in pixels?); 54/120 == 9/20
              var newWparam	  = WindowsMouseInput.WParam((Int16)(wheelDelta*9/20), keyState);
              SendMessage(hWnd, m.Msg, newWparam, m.LParam);
              return true;
            }
            break;
        }
      }
      return false;
		}
    #region Extern declarations
    /// <summary>P/Invoke declaration for user32.dll.WindowFromPoint</summary>
		/// <remarks><see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/ms633558(v=vs.85).aspx"/></remarks>
		/// <param name="pt">(Sign-extended) screen coordinates as a Point structure.</param>
		/// <returns>Window handle (hWnd).</returns>
		[DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point pt);
		/// <summary>P/Invoke declaration for user32.dll.SendMessage</summary>
		/// <param name="hWnd">Window handle</param>
		/// <param name="msg">Windows message</param>
		/// <param name="wp">WParam</param>
		/// <param name="lp">LParam</param>
		/// <returns></returns>
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    #endregion
    #endregion
