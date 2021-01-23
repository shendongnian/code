    /// <summary>
    /// Gets a <see cref="System.Double"/> that indicates how many seconds of time elapsed since the previous event.
    /// </summary>
    public double Time 
    {
        get { return elapsed; }
        internal set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException();
            elapsed = value;
        }
    }
