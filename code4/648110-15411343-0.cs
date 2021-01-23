    var user = new User() {
        FirstName = "Demis",
        LastName = "Bellot",
        Car = new Car() { Name = "BMW X6", Age = 3 }
    };
    
    var userDto = user.TranslateTo<UserDto>();
    
    Assert.That(userDto.FirstName, Is.EqualTo(user.FirstName));
    Assert.That(userDto.LastName, Is.EqualTo(user.LastName));
    Assert.That(userDto.Car, Is.EqualTo("{Name:BMW X6,Age:3}"));
