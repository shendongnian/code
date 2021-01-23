    int answer = 0;
    int myTotal = 0;
    
    if(int.TryParse(total1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture,out myTotal))
    {
         answer = myTotal * total2;
    }
