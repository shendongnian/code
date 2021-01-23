    Person person = new Person();
    person.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
    {
        Console.WriteLine("New name: " + person.FirstName);
    };
    person.FirstName = "ABC";
