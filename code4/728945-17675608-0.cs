    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Manager
    {
        public int MgrId { get; set; }
        public string MgrName { get; set; }
    }
    Mapper.Initialize(cfg =>
    {
       cfg.RecognizeDestinationPrefixes("Mgr");
       cfg.CreateMap<Employee, Manager>();
    });
    var manager = Mapper.Map<Employee, Manager>(new Employee { Id = 1, Name = "Fred" });
    
    Console.WriteLine("Id: {0}", manager.MgrId);
    Console.WriteLine("Name: {0}", manager.MgrName);
