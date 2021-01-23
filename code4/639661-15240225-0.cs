    [MapField("PersonID", "ID")]
    public class Person
    {
        public int    ID;
        public string LastName;
        public string FirstName;
        public string MiddleName;
        public Gender Gender;
    }
    IList<Person> GetPersonListSqlText()
    {
        using (DbManager db = new DbManager())
        {
            return db
                .SetCommand("SELECT * FROM Person")
                .ExecuteList<Person>();
        }
    }
