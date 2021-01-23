        protected override void OnLoad(EventArgs e) {
            if (Properties.Settings.Default.Size != Size.Empty) {
                Screen scr = Screen.FromPoint(Properties.Settings.Default.Location);
                int width = Math.Min(Properties.Settings.Default.Size.Width, scr.WorkingArea.Width);
                int height = Math.Min(Properties.Settings.Default.Size.Height, scr.WorkingArea.Height);
                this.Size = new Size(width, height);
                if (scr.WorkingArea.Contains(Properties.Settings.Default.Location))
                    this.Location = Properties.Settings.Default.Location;
                else this.Location = new Point(scr.Bounds.Left + (scr.Bounds.Width - width) / 2, 
                                               scr.Bounds.Top + (scr.Bounds.Height - height) / 2);
            }
            base.OnLoad(e);
        }
