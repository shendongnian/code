        public Keys ShortCutKey { get; set; }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == ShortCutKey) {
                button1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
