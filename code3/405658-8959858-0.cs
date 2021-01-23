    public class Entry {
      public string ItemName { get; set; }
      public int PriceLight { get; set; }
      public int PriceDark { get; set; }
    }
    
    Dictionary<string, Entry> pricesTilesBox = new Dictionary<string, Entry>();
    
    string  itemNameData=myReader["ItemName"].ToString().Trim();
    int light=Convert.ToInt32(myReader["PriceLight"]);
    int dark=Convert.ToInt32(myReader["PriceDark"]);
    pricesTilesBox.Add(itemNameData,new Entry { ItemName = itemNameData, PriceLight = light, PriceDark = dark });
    foreach (string key in pricesTilesBox.Keys) 
    {
     Console.WriteLine(key + '=' + pricesTilesBox[key]);
    }
