        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            try {  throw new Exception("Resetting FPU status word, please ignore"); }
            catch { }
        }
