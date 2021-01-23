    Console.WriteLine("Enter something...");
    IPropertyRepository repository = new PropertyRepository();
    PropertyServiceFactory factory = new PropertyServiceFactory(repository);
    IPropertyService _property = factory.Create();
    _property.TestMethod(Console.ReadLine());
