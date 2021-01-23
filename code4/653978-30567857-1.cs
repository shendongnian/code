    public Font GetAdjustedFont(Graphics GraphicRef, string GraphicString, Font OriginalFont, int ContainerWidth, int MaxFontSize, int MinFontSize, bool SmallestOnFail)
    {
       Font testFont = null;
       // We utilize MeasureString which we get via a control instance           
       for (int AdjustedSize = MaxFontSize; AdjustedSize >= MinFontSize; AdjustedSize--)
       {
          testFont = new Font(OriginalFont.Name, AdjustedSize, OriginalFont.Style);
    
          // Test the string with the new size
          SizeF AdjustedSizeNew = GraphicRef.MeasureString(GraphicString, testFont);
    
          if (ContainerWidth > Convert.ToInt32(AdjustedSizeNew.Width))
          {
             // Good font, return it
             return testFont;
          }
       }
    
       // If you get here there was no fontsize that worked
       // return MinimumSize or Original?
       if (SmallestOnFail)
       {
          return testFont;
       }
       else
       {
          return OriginalFont;
       }
    }
