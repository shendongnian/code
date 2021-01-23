    class Foo : IEquatable<Foo> {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Foo(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
        public bool Equals(Foo other) {
            return this.Id == other.Id && this.Name == other.Name;
        }
    }
