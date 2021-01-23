        private void Form1_Move(object sender, EventArgs e)
        {
            KeepBounds();
        }
        private void KeepBounds()
        {
            if (this.Left < SystemInformation.VirtualScreen.Left)
                this.Left = SystemInformation.VirtualScreen.Left;
            if (this.Right > SystemInformation.VirtualScreen.Right)
                this.Left = SystemInformation.VirtualScreen.Right - this.Width;
            if (this.Top < SystemInformation.VirtualScreen.Top)
                this.Top = SystemInformation.VirtualScreen.Top;
            if (this.Bottom > SystemInformation.VirtualScreen.Bottom)
                this.Top = SystemInformation.VirtualScreen.Bottom - this.Height;
        }
