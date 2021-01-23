    public class PersonData : Person, IPersonDBContext
    {
        // Implements Abstract Person Save() Method
        public override void Validate()
        {
            // Access properties of the base class (Abstract Person)
            this.FullName.ToString();
            this.SSN.ToString();
        }
        // Inplmenets IPersonDBContext Save()
        public void Save(Person person)
        {
            // Save logic here...
        }
        // Non-inhereted method
        public void Clone(Person person)
        {
            // Logic to make a member-wise clone.
        }
    }
