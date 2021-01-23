    public class Person {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public Person(int age, string name) {
            if (age < 0 || age > 150) throw new ArgumentOutOfRangeException();
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Age = age;
            Name = name;
        }
    }
