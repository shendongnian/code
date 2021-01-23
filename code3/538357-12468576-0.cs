        private void WndProcNonClientCalcSize(ref Message m)
        {
            if (m.WParam == WinAPI.FALSE)
            {
                this.Log(MethodInfo.GetCurrentMethod(), "FALSE");
                WinAPI.RECT rect = (WinAPI.RECT)Marshal.PtrToStructure(m.LParam, typeof(WinAPI.RECT));
                rect.Left += this._nonClientBorderThickness;
                rect.Top += this._nonClientHeight;
                rect.Right -= this._nonClientBorderThickness;
                rect.Bottom -= this._nonClientBorderThickness;
                Marshal.StructureToPtr(rect, m.LParam, false);
                m.Result = WinAPI.FALSE;
            }
            else if (m.WParam == WinAPI.TRUE)
            {
                this.Log(MethodInfo.GetCurrentMethod(), "TRUE");
                WinAPI.NCCALCSIZE_PARAMS csp;
                csp = (WinAPI.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(WinAPI.NCCALCSIZE_PARAMS));
                WinAPI.RECT rectNewClient = csp.rectProposed;
                rectNewClient.Left += this._nonClientBorderThickness;
                rectNewClient.Top += this._nonClientHeight;
                rectNewClient.Right -= this._nonClientBorderThickness;
                rectNewClient.Bottom -= this._nonClientBorderThickness;
                csp.rectProposed = rectNewClient;
                csp.rectBeforeMove = csp.rectProposed;
                Marshal.StructureToPtr(csp, m.LParam, false);
                m.Result = (IntPtr)(WinAPI.NCCALCSIZE_RESULTS.ValidRects);
            }
        }
