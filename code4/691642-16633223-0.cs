    public class SoruBase
    {
        public Guid? SoruId { get; set; }
        public Guid? SoranId { get; set; }
        public int? BakilmaSayisi { get; set; }
        public string Baslik { get; set; }
        public int? KategoriId { get; set; }
    }
    public class Soru : SoruBase
    {
        public string HtmlGovde { get; set; }
        public string MarkdownGovde { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public List<Etiket> Etiketler { get; set; }
    }
    public class SoruSayfa : SoruBase
    {
        public int DurumId { get; set; }
        public double SoruPuani { get; set; }
        public int CevapSayisi { get; set; }
        public int BakilmaSayisi { get; set; }
        public string KullaniciAdi { get; set; }
        public double? KisiAlanPuani { get; set; }
    }
