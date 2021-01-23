        void DropDownBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    ShowPopup();
                    e.SuppressKeyDown = true; // Don't pass it to the underlying control
                    break;
            }
        }
