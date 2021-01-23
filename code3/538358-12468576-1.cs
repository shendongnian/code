        private void WndProcSysCommand(ref Message m)
        {
            UInt32 param;
            if (IntPtr.Size == 4)
                param = (UInt32)(m.WParam.ToInt32());
            else
                param = (UInt32)(m.WParam.ToInt64());
            if ((param & 0xFFF0) == (int)WinAPI.SystemCommands.SC_RESTORE)
            {
                this.Height = this._storedHeight;
                this.Width = this._storedWidth;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this._storedHeight = this.Height;
                this._storedWidth = this.Width;
            }
            base.WndProc(ref m);
        }
