    public class DataAccessClass
    {
        public static IEnumerable<string> GetCountries()
        {
            // access the database and retrieve all the values
            // returns IEnumerable (a list of items)
        }
    
        public static IEnumerable<string> GetStates(string selectedCountry)
        {
            // access the database and retrieve all the corresponding states
            // linq2sql: var states = from o in db.States
            //                        where o.country = selectedCountry
            //                        select o;
            // returns IEnumerable (a list of items)
        }
    }
