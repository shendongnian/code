    public class TheJson
    {
        public string status { get; set; }
        public client[] clients { get; set; }
        public dossier[] dossiers { get; set; }
    }
    
    
    public class client
    {
         public string ClientID { get; set; }
         public string Fullname { get; set; }
         public bool Inactive { get; set; }
    }
    
    public class dossier
    {
         public string CreateDate { get; set; }
         public string DossierName { get; set; }
    }
