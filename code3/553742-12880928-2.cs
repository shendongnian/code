    public ObservableCollection<Car> DataCollection { get; set; }
    DataCollection = new ObservableCollection<Car> 
    { 
        new Car { Name = "VW Golf GTI", Id = 30000 }, 
        new Car { Name = "Porsche GT3", Id = 30000 }, 
        new Car { Name = "Porsche Cayenne", Id = 80000 }, 
        new Car { Name = "BMW M6", Id = 90000 }
    };
