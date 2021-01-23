        private int WM_KEYDOWN = 0x100;
        public override bool PreProcessMessage(ref Message msg)
        {
            Keys key = (Keys)msg.WParam.ToInt32();
            if (msg.Msg == WM_KEYDOWN && key == Keys.Tab)
            {
                if (itemSearchControl.Visible)
                {
                    bool moveForward = !IsShiftKeyPressed();
                    bool result = itemSearchControl.SelectNextControl(itemSearchControl.ActiveControl, true, true, true, true);
                    return true;
                }
            }
            return base.PreProcessMessage(ref msg);
        }
