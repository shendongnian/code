    for(int i=0; i<rtb.Lines.Length; i++) 
    { 
       string text = rtb.Lines[i];
       rtb.Select(rtb.GetFirstCharIndexFromLine(i), text.Length); 
       rtb.SelectionColor = colorForLine(text); 
    } 
    private Color colorForLine(string line)
    {
        if(line.Contains("[INFO]", StringComparison.InvariantCultureIgnoreCase) return Color.Green;
        if(line.Contains("[ERROR]", StringComparison.InvariantCultureIgnoreCase) return Color.Red;
        return Color.Black;
    }
