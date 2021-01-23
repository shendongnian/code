        /// <summary>
        /// Gets a handle to the combobox
        /// </summary>
        private IntPtr HwndCombo
        {
            get
            {
                COMBOBOXINFO pcbi = new COMBOBOXINFO();
                pcbi.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(pcbi);
                NativeMethods.GetComboBoxInfo(this.Handle, ref pcbi);
                return pcbi.hwndCombo;
            }
        }
