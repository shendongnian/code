        var user = new User
        {
            FirstName = "TestFirstName",
            LastName = "TestLastName",
            Unit = Session.Load<Unit>(unitId)
        }
