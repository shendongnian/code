    string ConvertDate(string dateToConvert)
    { 
        dateToConvert= dateToConvert.PadLeft(7, '0');
        int c;
        int.TryParse(dateToConvert.Substring(0,1), out c);	
        c = (c * 100) + 1900;
        int y;
        int.TryParse(dateToConvert.Substring(1,2), out y);	
	
        return (c+y).ToString() + dateToConvert.Substring(3,4);
    }
