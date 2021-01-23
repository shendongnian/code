    public class GenericRepositoryExample
    {
        public void Save<T>(IList<T> persons, SaveDelegate<T> save)
        {
            foreach (T person in persons)
            {
                Console.WriteLine(save(person));
            }
        }
    }
