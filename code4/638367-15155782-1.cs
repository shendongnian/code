    using System.ComponentModel;
    static void Main(string[] args) {
        ClassA a = new ClassA();
        a.PropertyChanged += PropertyChanged;
        a.ClassAProperty = "Default value";
        ClassB b = new ClassB();
        b.PropertyChanged += PropertyChanged;
        b.ClassBProperty = "Default value";
        b.ClassBProperty = "new value in B";
        a.ClassAProperty = "new value in A";
        Console.Read();
    }
    static void PropertyChanged(object sender, PropertyChangedEventArgs e) {
        Console.WriteLine("Property {0} on object {1} was changed, the value is \"{2}\"", e.PropertyName, sender.GetType().Name, sender.GetType().GetProperty(e.PropertyName).GetValue(sender));
    }
