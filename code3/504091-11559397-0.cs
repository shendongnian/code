    int currentPrice = 0;
    
    if(!string.IsEmptyOrNull(currentPrice1.Text))
    {
       int price = 0;
       if(int.TryParse(currentPrice1.Text, out price))
       {
           currentPrice = price ;
       }
    }
