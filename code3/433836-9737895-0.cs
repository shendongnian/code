        private bool closing;
        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (!closing) {
                closing = true;
                // Do your stuff
                //...
                this.BeginInvoke(new Action(() => this.Close()));
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
