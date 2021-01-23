    [DefaultValue(typeof(Color), "Window"), Description("Overridden property")]
    override public Color BackColor {
        get {
            return base.BackColor;
        }
        set {
            _backColor = value;
            MyResetColors();
        }
    }
    private void MyResetColors() {
        base.BackColor = this.IsMandatory && !DesignMode ? this.MandatoryBackColor : _backColor;
    }
