    public abstract class Person
    {
        public string FullName { get; set; }
        public string SSN { get; set; }
        public abstract void Save();
    }
    public class PersonData : Person
    {
        // Implements Abstract Person Save() Method
        public override void Save()
        {
            // Save logic here...
        }
        // Non-inherited member...
        public void Validate()
        {
            // Access properties of the base class (Abstract Person)
            this.FullName.ToString();
            this.SSN.ToString();
        }
    }
