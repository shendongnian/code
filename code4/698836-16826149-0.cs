    protected override void SetVisibleCore(bool value) {
        if (!this.IsHandleCreated) {
            value = false;
            this.CreateHandle();
        }
        base.SetVisibleCore(value);
    }
