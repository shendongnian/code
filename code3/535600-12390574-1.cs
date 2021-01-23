    public class CsvParser : IParser
    {
        public IList<Person> ReadString(string path)
        {
            List<Person> result = new ...;
            For each line in the string
            {
                // Code to get the columns from the current CSV line
                Person p = new Person();
                p.Name = columns[0];
                p.Age = columns[1].AsInt();
                result.add(item);
            }
            return result;
        }
    }
