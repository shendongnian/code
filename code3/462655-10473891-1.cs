    public Color[] AvailableColors = new Color[] { Colors.Red, Colors.Blue, Colors.Green};         
    private int _nextColorIndex = 0;
    public Dictionary<string,Color> ColorMappings = new Dictionary<string,Color>();
    public Color GetNextColor () 
    {
        Color nextColor = AvailableColors[_nextColorIndex];
        _nextColorIndex++;
        if (_nextColorIndex == AvailableColors.Length)
            _nextColorIndex = 0; // Restart colors and reuse.
        return nextColor;
    }
    
    public void AssignColor (string myString)
    {
        ColorMappings.Add(myString, GetNextColor());
    }
