        /// <summary>
        /// Gets a handle to the combo's drop-down list
        /// </summary>
        private IntPtr HwndDropDown
        {
            get
            {
                COMBOBOXINFO pcbi = new COMBOBOXINFO();
                pcbi.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(pcbi);
                NativeMethods.GetComboBoxInfo(this.Handle, ref pcbi);
                return pcbi.hwndList;
            }
        }
