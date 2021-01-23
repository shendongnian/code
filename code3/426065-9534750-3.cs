    User currentUser = new User()
    {
        Id = 1,
        Name = "Vinicius",
        OtherCars = new List<Car>()
        {
            new Car()
            {
                Id = 2,
                Name = "Corsa II",
                Color = "Azul"
            },
            new Car()
            {
                Id = 3,
                Name = "Palio",
                Color = "Vermelho"
            },
            new Car()
            {
                Id = 4,
                Name = "Fusca",
                Color = "Azul"
            }
        },
        MainCar = new Car()
        {
            Id = 1,
            Name = "Corsa",
            Color = "Preto"
        }
    };
    User updatedUser = new User()
    {
        Id = 1,
        Name = "Vinicius Ottoni",
        OtherCars = new List<Car>()
        {
            new Car()
            {
                Id = 5,
                Name = "Voyage",
                Color = "Azul"
            },
            new Car()
            {
                Id = 6,
                Name = "Voyage II",
                Color = "Vermelho"
            },
            new Car()
            {
                Id = 4,
                Name = "Fusca",
                Color = "Rosa"
            }
        },
        MainCar = new Car()
        {
            Id = 2,
            Name = "Voyage",
            Color = "Vinho"
        }
    };
    this.UpdateAllProperties<int, User>(currentUser, updatedUser);
