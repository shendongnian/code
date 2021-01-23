    public void Run() 
    { 
        DataElement data = DataElement.Create("Element");
        DataElement parI = DataElement.CreateParam("IntElement", 22);
        DataElement parD = DataElement.CreateParam("DblElement", 3.14); 
        DataElement locl = DataElement.CreateLocal("LocalElement"); 
    } 
