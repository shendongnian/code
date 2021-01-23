    public class Person
    {
        public String Name { get; set; }
    
        public String Family { get; set; }
        
        public Int32 Sex  { get; set; }
        
        public GenderEnum EnumeratedSex
        {
            get
            {
                return Sex == 1 ? GenderEnum.Man : GenderEnum.Woman;
            }
        }
    }
    public enum GenderEnum
    {
        Man = 1,
        Woman = 2
    }
