    // Note: typeAList = List<TypeA> with values populated in the test itself
    
    System.Data.Linq.Moles.MTable<TypeA> typeATable = new System.Data.Linq.Moles.MTable<TypeA>();
    typeATable.Bind(typeAList);
    typeATable.ProviderSystemLinqIQueryableget = () => typeAList.AsQueryable().Provider;
    typeATable.ExpressionSystemLinqIQueryableget = () => typeAList.AsQueryable().Expression;
    MyLibrary.Data.Moles.MMyDataContext.AllInstances.TypeAsGet = (c) => { return typeATable; };
         
    System.Data.Linq.Moles.MTable<TypeB> typeBTable = new System.Data.Linq.Moles.MTable<TypeB>();
    typeBTable.Bind(typeBList);
    typeBTable.ProviderSystemLinqIQueryableget = () => typeBList.AsQueryable().Provider;
    typeBTable.ExpressionSystemLinqIQueryableget = () => typeBList.AsQueryable().Expression;
    MyLibrary.Data.Moles.MMyDataContext.AllInstances.TypeBsGet = (c) => { return typeBTable; };
