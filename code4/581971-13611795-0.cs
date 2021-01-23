    public interface IPerson
    {
        string FullName { get; set; }
        string SSN { get; set; }
    }
    public interface IPersonDBContext
    {
        void Save(IPerson person);
    }
    public class PersonData : IPerson, IPersonDBContext
    {
        // Implements IPerson FullName
        public string FullName { get; set; }
        // Implements IPerson SSN
        public string SSN { get; set; }
        // Implements IPersonDBContext Save()
        public void Save(IPerson person)
        {
            // Code to save the IPerson instance to the DB...
        }
        // Added method, not included in any interface...
        public void Validate(IPerson person)
        {
            // Code to validate the IPerson instance...
        }
    }
