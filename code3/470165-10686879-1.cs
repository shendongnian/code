    class A
    {
        private void Display()
        {
            var person= Passing();
            Console.WriteLine(person.Name + ": " + person.Age);
        }
        private Person Passing()
        {
            return new Person() {Name = "John Doe", Age = 99 };
        }
    }
