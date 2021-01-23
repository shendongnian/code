    List<Person> people = new List<Person>();
    people.Add(new Person() {Id = 3, Location = "XYZ"});
    
    var properties = (from prop in typeof (Person).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        let parameter = Expression.Parameter(typeof (Person), "obj")
                        let property = Expression.Property(parameter, prop) 
                        let lambda = Expression.Lambda<Func<Person, object>>(Expression.Convert(property, typeof(object)), parameter).Compile()
                        select
                        new
                            {
                                Getter = lambda,
                                Name = prop.Name
                            }).ToArray();
    
    
    foreach (var person in people)
    {
        foreach (var property in properties)
        {
            string name = property.Name;
            object value = property.Getter(person);
            //do something with property name / property value combination.
    
        }
    }
