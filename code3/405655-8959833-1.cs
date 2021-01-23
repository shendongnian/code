    public class TileBox
    {
     public string Name {get; set;}
     public decimal PriceLight {get; set;}
     public decimal PriceDark {get; set;}
    }
    
    List<TileBox> tileBoxes = new List<TileBox>();
    //loop here to add TileBoxes to the List
    {
     TileBox tileBox = new TileBox();
     tileBox.Name = myReader["ItemName"].ToString().Trim();
     tileBox.PriceLight = Convert.ToDecimal(myReader["PriceLight"]);
     tileBox.PriceDark = Convert.ToDecimal(myReader["PriceDark"]);
     tileBoxes.Add(tileBox);
    }
