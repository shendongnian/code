    public class CustomerPersonConverter : TypeConverter<Tuple<Person, Person>, Person>
    {
        protected override Person ConvertCore(Tuple<Person, Person> source)
        {
            var orginalValues = source.Item1;
            var updatedValues = source.Item2;
            var result = new Person
                {
                    FirstName = string.IsNullOrEmpty(updatedValues.FirstName) ? orginalValues.FirstName : updatedValues.FirstName,
                    LastName = string.IsNullOrEmpty(updatedValues.LastName) ? orginalValues.LastName : updatedValues.LastName
                };
            return result;
        }
    }
