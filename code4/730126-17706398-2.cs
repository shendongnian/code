    protected Color GetColorForLabel(string text)
    {
        int theTWAValue;
        if (text != null && int.TryParse(text, out theTWAValue) && theTWAValue >= 0)
        {
            return (theTWAValue < 90) ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;
        }
        return System.Drawing.Color.Green;
    }
        
