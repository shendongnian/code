    public class Person
    {
        public int Id { get; set; }
        public override bool Equals(object obj)
        {
            var person = obj as Person;
            if (person == null)
            {
                return false;
            }
            return person.Id == this.Id;
        }
    }
