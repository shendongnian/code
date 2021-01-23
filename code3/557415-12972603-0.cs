    class Person {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<string> Children { get; set; }
        public Person() {
            Children = new List<string>();
        }
        public Person(string first, string last, IEnumerable<string> children) {
            FirstName = first;
            LastName = last;
            Children = children.ToList();
        }
        ...
    }
