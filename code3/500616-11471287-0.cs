    public class Specials
        {
            public int PurchaserID { get; set; }
            public int PurchaserSerial { get; set; }
            public string Address { get; set; }
            public int Fax { get; set; }
            public int NumberEconomic { get; set; }
        }
    
    public static List<Specials> GetList()
        {
            Entity conn = new Entity();
            var lst = (from PS in conn.PurchaserSpecials
                    select new Specials
                    {
                        PurchaserID =  PS.PurchaserID,
                        PurchaserSerial = PS.PurchaserSerial,
                        Address = PS.Purchaser.Address,
                        Fax = PS.Purchaser.Fax,
                        NumberEconomic = PS.Purchaser.NumberEconomic
                    }).ToList();
    return lst;
        }
