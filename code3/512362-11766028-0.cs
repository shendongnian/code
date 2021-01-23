    public string RoomTitleCase
    {
        get
        {
            System.Globalization.CultureInfo cultureInfo =     
                     System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
    
            string titleCase = textInfo.ToTitleCase(Room.ToLower());
            return titleCase;
        }
    }
