    public Color BackColor
    {
        override set
        {
            base.BackColor = value;
            OnBackColorChanged(EventArgs.Empty);
        }
    }
