    // I first load the assembly
    System.Reflection.Assembly dal = System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(pBinPath, pDALAssemblyName));
    
    // I then look for types implementing ICustomerRepository 
    var addressRepositoryContract = typeof(QSysCamperCore.Domain.IAddressRepository);
    var addressRepositoryImplementation = dal.GetTypes()
        .First(p => addressRepositoryContract.IsAssignableFrom(p));
    ...
