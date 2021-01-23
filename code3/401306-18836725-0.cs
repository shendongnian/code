    public class PersonalInfo
    {
        public int Id { get; set; } //EF will automatically figure out this is your PK
        public double Height { get; set; }
        public string Ethnicity { get; set; }
        public string DriversLicence { get; set; }
        //EF automatically figures out that the PersonId property refers to your Person table
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } //navigation property so you can do personalInfo.Person.FirstName
        
    }
