    interface IPerson
    {
        string Name { get; set; }
    }
    interface IDoctor : IPerson
    {
        string Specialty {get; set; }
    }
    class Doctor : IDoctor
    {
       public string Name { get; set; }
       public string Specialty {get; set;}
    }
