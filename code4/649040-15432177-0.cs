        public const int CB_GETDROPPEDSTATE = 0x0157;
        public static bool GetDroppedDown(ComboBox comboBox)
        {
            Message comboBoxDroppedMsg = Message.Create(comboBox.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
            MessageWindow.SendMessage(ref comboBoxDroppedMsg);
            return comboBoxDroppedMsg.Result != IntPtr.Zero;
        }
        public const int CB_SHOWDROPDOWN = 0x14F;
        public static bool ToogleDropDown(ComboBox comboBox)
        {
            int expand = GetDroppedDown(comboBox) ? 0 : 1;
            int size = Marshal.SizeOf(new Int32());
            IntPtr pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteInt32(pBool, 0, expand);  // last parameter 0 (FALSE), 1 (TRUE)
            Message comboBoxDroppedMsg = Message.Create(comboBox.Handle, CB_SHOWDROPDOWN, pBool, IntPtr.Zero);
            MessageWindow.SendMessage(ref comboBoxDroppedMsg);
            Marshal.FreeHGlobal(pBool);
            return comboBoxDroppedMsg.Result != IntPtr.Zero;
        }
