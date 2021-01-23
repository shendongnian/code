    SqlCommand command = new SqlCommand();
    Person person = new Person()
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "johndoe@domain.com"
    };
    foreach (var pi in person.GetType().GetProperties())
    {
        var attribute = (ParameterAttribute)pi.GetCustomAttributes(typeof(ParameterAttribute), false).FirstOrDefault();
        if (attribute != null)
        {
            command.Parameters.AddWithValue(string.Format("@{0}", attribute.ParameterName), pi.GetValue(person, null));
        }
    }
