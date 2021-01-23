    public class County
    {
        public int CountyId { get; set; }
        public int StateProvinceId { get; set; }
        public String Name { get; set; }
        [ScaffoldColumn(false)]
        public String StatePostalAbbreviation { get; set; }
    
        [ForeignKey("StateProvinceId")]
        public virtual StateProvince StateProvince { get; set; }
    }
