    public class Store
    {
       
      [StringLength(5)]
        public string Zip5 { get; set; }
        public virtual List<StoreReport> StoreReports { get; set; }  //use a list here
     }
