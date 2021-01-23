       public void ChangeDigit(byte Place, byte To) 
       { 
           string Item = Convert.ToString(ID, CultureInfo.InvariantCulture);
           if(Place > Item.Length || Place < 1)
               throw new ArgumentOutOfRangeException("Place");
           Item = Item.Remove(Place-1) + To.ToString() + Item.Substring(Place)
           ID = uint.Parse(Item, CultureInfo.InvariantCulture);
       } 
