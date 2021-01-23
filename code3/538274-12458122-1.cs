    public class  veritabani_islemleriModel{
     public String KolonAdi { get; set; }
     public String En { get; set; }
     public String Boy { get; set; }
     public String Yükseklik { get; set; }
     public String ID { get; set; }
    }
    
    and then 
    public class veritabani_islemleri
    {
        public List<veritabani_islemleriModel> kolonlistele()
        {
        using(pehkEntities ctx = new pehkEntities())
    
    
    
            var result =from k in ctx.Kolons
                   select new veritabani_islemleriModel
                   {
                       KolonAdı = k.KolonAdi,
                       En = k.En,
                       Boy = k.Boy,
                       Yükseklik = k.Yukseklik,
                       ID = k.KolonID
                   };
    
            return result.Tolist();
        }
    }
