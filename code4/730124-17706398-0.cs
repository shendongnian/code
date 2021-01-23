    protected Color GetColorForLabel(string text)
    {
        int theTWAValue;
        if (text != null && int.TryParse(text, out theTWAValue) && theTWAValue >= 0)
        {
            return (theTWAValue < 90) ? Color.Yellow : Color.Red;
        }
        return Color.Black;
    }
        
