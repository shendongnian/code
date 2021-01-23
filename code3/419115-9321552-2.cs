    Mapper.Initialize(cfg =>
    {
       cfg.RecognizeDestinationPrefixes("Cust_");
       cfg.CreateMap<A, B>();
    });
    A a = new A() {FirstName = "Cliff", LastName = "Mayson"};
    B b = Mapper.Map<A, B>(a);
    //b.Cust_FirstName is "Cliff"
    //b.Cust_LastName is "Mayson"
