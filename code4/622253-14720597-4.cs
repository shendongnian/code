          public void EnableOrDisableCloseButton(bool Enabled)
          {
            IntPtr hSystemMenu = GetSystemMenu(this.Window.Handle, false);
            EnableMenuItem(hSystemMenu, SC_CLOSE, (uint)(MF_ENABLED | (Enabled ? MF_ENABLED : MF_GRAYED)));
          }
