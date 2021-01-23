    private KnownColor _UseColor = KnownColor.Red;
    
    /// <summary>
    /// Gets or sets the name of the colour
    /// </summary>
    public string ColorName
    {
        get
        {
            return this._UseColor.ToString();
        }
        set
        {
            if (Enum.IsDefined(typeof(KnownColor), value))
                this._UseColour = (KnownColor)Enum.Parse(typeof(KnownColor), value);
        }
    }
    
    private Dictionary<string, Brush> _knownBrushes = new Dictionary<string, Brush>();
    
    public Brush ColorBrush
    {
        get
        {
            if (!_knownBrushes.ContainsKey(_UseColor)) {
                _knownBrushes[_UseColor] = new SolidBrush(Color.FromKnownColor(this._UseColor));
            }
            
            return _knownBrushes[_UseColor];
        }
    }
