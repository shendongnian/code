    class Control
    {
         public int UseThemeColor = -1;    
    
         public Color Color { 
             get { return (UseThemeColor==-1 ? _color : ThemeColor.GetByIndex(UseThemColor); } 
             set { _color = value; UseThemColor = -1; }
         }
    }
