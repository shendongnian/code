        private void smartRefresh()
        {
            if (oldBackColor != BackColor) {
                oldBackColor = BackColor;
                Hide();
                Application.DoEvents();
                Show();
                Application.DoEvents();
            }
        }
