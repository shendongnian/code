        bool IsMenuStripOpen  = false;
        
        void rootItem_DropDownOpened(object sender, EventArgs e)
        {
            IsMenuStripOpen = true;
        }
        void rootItem_DropDownClosed(object sender, EventArgs e)
        {
            IsMenuStripOpen = false;
        }
        void Form3_MouseWheel(object sender, MouseEventArgs e)
        {
            if (IsMenuStripOpen)
            {
                if (e.Delta > 0)
                {
                    Keyboard.KeyUp();
                }
                else
                {
                    Keyboard.KeyDown();
                }
            }
        }
