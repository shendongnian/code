        public class PersonInfo : IEquatable<PersonInfo>
        {
            public string Login { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public bool Active { get; set; }
            public bool Equals(PersonInfo other)
            {
                //Check whether the compared object is null.
                if (Object.ReferenceEquals(other, null)) return false;
                //Check whether the compared object references the same data.
                if (Object.ReferenceEquals(this, other)) return true;
                //Check whether the properties are equal.
                return Login.Equals(other.Login) && FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && Age.Equals(other.Age) && Active.Equals(other.Active);
            }
            public override int GetHashCode()
            {
                int hashLogin = Login == null ? 0 : Login.GetHashCode();
                int hashFirstName = FirstName == null ? 0 : FirstName.GetHashCode();
                int hashLastName = LastName == null ? 0 : LastName.GetHashCode();
                int hashAge = Age.GetHashCode();
                int hashActive = Active.GetHashCode();
                //Calculate the hash code.
                return (hashLogin + hashFirstName + hashLastName) ^ (hashAge + hashActive);
            }
        }
