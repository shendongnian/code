    public enum Gender 
    { 
        Male, Female
    }
    public class Staff 
    { 
        public Staff(Gender gender)
        {
            this.Gender = gender;
        }
        public Gender Gender { get; private set; }
    } 
    public class FemaleStaff : Staff
    { 
        public FemaleStaff() : base(Gender.Female)
        {
        }
    }
    
    public class MaleStaff : Staff
    { 
        public MaleStaff () : base(Gender.Male)
        {
        }
    } 
