        protected override void SetVisibleCore(bool value) {
            if (!this.IsHandleCreated) {
                this.CreateHandle();
                value = false;
            }
            base.SetVisibleCore(value);
        }
