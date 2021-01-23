    public static List<Products> GetList()
    {
        Entity conn = new Entity();
        var lst = (from PS in conn.PurchaserSpecials
                select new
                {
                    PS.PurchaserID,
                    PS.PurchaserSerial,
                    PS.Purchaser.Address,
                    PS.Purchaser.Fax,
                    PS.Purchaser.NumberEconomic
                }).ToList();
        return lst;
    }
    public class Products
    {
        //Fields you are using in the query.
    }
