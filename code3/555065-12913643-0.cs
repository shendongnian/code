    public class Person
    {
        public int Id { get; set; }
        public override bool Equals(obj other)
        {
            var person = other as Person;
            if (person == null)
            {
                return false;
            }
            return person.Id == this.Id;
        }
    }
