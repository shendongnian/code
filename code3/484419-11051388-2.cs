    List<Person> people = ...;
    Type type = typeof(Person);
    PropertyInfo[] properties = type.GetProperties();
    var sb = new StringBuilder();
    // First line contains field names
    foreach (PropertyInfo prp in properties) {
       if (prp.CanRead) {
          sb.Append(prp.Name).Append(';');
       }
    }
    sb.Length--; // Remove last ";"
    sb.AppendLine();
    foreach (Person person in people) {
        foreach (PropertyInfo prp in properties) {
           if (prp.CanRead) {
              sb.Append(prp.GetValue(person, null)).Append(';');
           }
        }
        sb.Length--; // Remove last ";"
        sb.AppendLine();
    }
    File.AppendAllText("C:\Data\Persons.csv", sb.ToString());
