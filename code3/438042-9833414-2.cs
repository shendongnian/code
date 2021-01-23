        public class Employee
        {
            // I want to completely ignore ID in the comparison
            public int ID { get; set; }
            // I want to use FirstName and LastName in comparison
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public override bool Equals(object obj)
            {
                var other = obj as Employee;
                return this.FirstName == other.FirstName && this.LastName == other.LastName;
            }
            public override int GetHashCode()
            {
                return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
            }
        }
