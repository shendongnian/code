    private float _voltageRange;
    public float VoltageRange
    {
      get { return _voltageRange + ((10F/100F)*_voltageRange); }
      set { _voltageRange = value; }
    }
