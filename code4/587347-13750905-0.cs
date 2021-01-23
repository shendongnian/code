    //model
    public List<MyClass> storeLocations { get; set; }
    
    //snip
    var comboType = from c in context.sistema_Armazenamento
                    select new MyClass
                            {
                                id = c.id,
                                local = c.caminhoRepositorio
                            };
    storeLocations = comboType.ToList();
