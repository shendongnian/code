        protected override void OnLoad(EventArgs e) {
            var scr = Screen.FromPoint(this.Location);
            this.Size = new Size((int)(scr.WorkingArea.Width * 0.75),
                                 (int)(scr.WorkingArea.Height * 0.80));
            this.Location = new Point((scr.WorkingArea.Width - this.Width) / 2,
                                      (scr.WorkingArea.Height - this.Height) / 2);
            base.OnLoad(e);
        }
