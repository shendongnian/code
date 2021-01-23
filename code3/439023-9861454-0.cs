        private bool fastRender;
        protected override void OnResizeBegin(EventArgs e) {
            fastRender = true;
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e) {
            base.OnResizeEnd(e);
            fastRender = false;
            this.Invalidate();
        }
