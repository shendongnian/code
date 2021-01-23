    public class City
    {
        // ...
        static City()
        {
            RepositoryManager.Register(LoadAllCitiesFromDatabase);
        }
        // ...
    }
