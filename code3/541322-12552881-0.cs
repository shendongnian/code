        protected override void OnResizeEnd(EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized) {
                Properties.Settings.Default.Location = this.Location;
                Properties.Settings.Default.Size = this.Size;
                Properties.Settings.Default.Save();
            }
            base.OnResizeEnd(e);
        }
