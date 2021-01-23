    var service = new ServiceEntity {
        FirstName = "Sergey",
        LastName = "Berezovskiy",
        Salary = 5000,
        BkName = "Laziness in Action",
        BkDescription = "...",
        BkPrice = 42
    };
    var business = Mapper.Map<BusinessEntity>(source);
    var anotherService = Mapper.Map<ServiceEntity>(business);
    
