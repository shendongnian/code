        private void frmBase_Load(object sender, EventArgs e) {
            if (this.Site == null || !this.Site.DesignMode) {
                // Not in design mode, okay to do dangerous stuff...
                this.UpdateOnline();
            }
        }
