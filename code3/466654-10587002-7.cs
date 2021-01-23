    public float RotorAngle
    {
        get { return mRotorAngle; }
        set
        {
            mRotorAngle = value;
            Invalidate();
        }
    }
