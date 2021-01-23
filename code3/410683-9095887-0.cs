        protected override void OnValidating(CancelEventArgs e) {
            foreach (Control ctl in this.Controls) {
                if (errorProvider1.GetError(ctl) != "") e.Cancel = true;
            }
            base.OnValidating(e);
        }
