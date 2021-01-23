    [Table(Name="Emp")]
    public class Emp
    {
        [Column(Name = "No", IsPrimaryKey = true)]
        public int Id { get; set; }
    
        [Column(Name="Name")]
        public string Name { get; set; }
    
        [Column(Name = "Status")]
        private char Status { get; set; }
        
        public bool BoolStatus
        {
            get { return Status == 'Y' ? true : false; }
            set
            {
                if (value)
                    Status = 'Y';
                else
                    Status = 'N';
            }
        }
       public override string ToString()
        {
          return string.Format("{0} {1} {2}", Id, Name, BoolStatus);
         }
    }
