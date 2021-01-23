    public Fill GenerateFill()
    {
        Fill fill = new Fill();
        
        PatternFill patternFill = new PatternFill(){ PatternType = PatternValues.Solid };
        ForegroundColor foregroundColor1 = new ForegroundColor(){ Rgb = "FFFFFF00" };
        BackgroundColor backgroundColor1 = new BackgroundColor(){ Indexed = (UInt32Value)64U };
        
        patternFill.Append(foregroundColor1);
        patternFill.Append(backgroundColor1);
        
        fill.Append(patternFill);
    
        return fill;
    }
