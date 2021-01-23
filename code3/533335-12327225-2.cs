            var parameters = new DynamicParameters();
            parameters.Add("city", "SomeCity");
            parameters.Add("firstName", "John");
            parameters.Add("lastName", "Smith");
            var result = dbConnection.Query<string>(
              "update Students set FirstName = @firstName, City = @city where LastName = @lastName",
              parameters
            );
