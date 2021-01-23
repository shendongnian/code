    public override Color BackColor
    {
        get
        {
            return base.BackColor;
        }
        set
        {
            base.BackColor = value;
            OnBackColorChanged(EventArgs.Empty);
        }
    }
