    public enum Gender 
    {
        Male, Female
    }
    
    public class Human
    {
        public Gender Gender { get; set; }
    
        public void setHeight(Human person)
        {
            if (person.Gender == Gender.Male)
            {
    
            }
        }
    }
