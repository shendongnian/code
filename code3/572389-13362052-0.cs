    public override bool Visible
    {
        get
        {
            var b = base.Visible;
            if (!b || this.ControlShouldNotBeRendered())
                return false;
            return true;
        }
        set
        {
            base.Visible = value;
        }
    }
