        double panelLeftProp;
        private void panelLeft_Resize(object sender, EventArgs e)
        {
            panelLeftProp = panelLeft.Width / this.Width;
        }
        private void Form_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;
            panelLeft.Width = (int) (this.Width * panelLeftProp);
        }
