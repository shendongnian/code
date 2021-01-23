        public void SendKey(int keyValue, Keys modifiers)
        {
            VirtualKeyCode key;
            if (modifiers.Equals(Keys.None))
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    InputSimulator.SimulateKeyDown(key);
                    InputSimulator.SimulateKeyUp(key);
                }   
            }
            else if (modifiers.Equals(Keys.Shift) && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
            {
                if (Enum.TryParse(VkKeyScan(((char) keyValue)).ToString(), out key))
                {
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.SHIFT, key);
                }
            }
            else if (modifiers.Equals(Keys.Control) && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, key);
                }
            }
            else if (modifiers.Equals(Keys.Alt) && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    //Alt is named MENU for legacy purposes.
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, key);
                }
            }
            
        }
