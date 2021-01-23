    public class POCOConfiguration : EntityTypeConfiguration<POCO> where POCO : new()
    {     
        public POCOConfiguration()
        {
            var poco = new POCO();
        } 
    } 
