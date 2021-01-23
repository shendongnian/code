    public class Human
    {
        public Human(int id, string address, string name, IEnumerable<ContactNumber> contactNumbers) : this(id, address, name)
        {
            ContactNumbers = new List<ContactNumber>(contactNumbers);
        }
        public Human(int id, string address, string name, params ContactNumber[] contactNumbers) : this(id, address, name)
        {
            ContactNumbers = new List<ContactNumber>(contactNumbers);
        }
    }
    // Using the first constructor:
    List<ContactNumber> numbers = List<ContactNumber>() {
        new ContactNumber(1),
        new ContactNumber(2),
        new ContactNumber(3)
    };
    var human = new Human(1, "Address", "Name", numbers);
    // Using the second constructor:
    var human = new Human(1, "Address", "Name",
        new ContactNumber(1),
        new ContactNumber(2),
        new ContactNumber(3)
    );
