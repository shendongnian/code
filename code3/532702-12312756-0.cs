    RuntimeTypeModel.Default.Add(typeof(Product), false).Add("Name", "Sku");
    RuntimeTypeModel.Default.Add(typeof(Company), false).Add("Name", "Address",
             "Type", "Products");
    RuntimeTypeModel.Default.Add(typeof(User), false).Add("FirstName", "LastName",
             "Age", "BirthDate", "Friends", "Company");
    RuntimeTypeModel.Default.Add(typeof(BaseUser), false).Add(10, "SSN")
             .AddSubType(1, typeof(User));
