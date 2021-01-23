    public class PersonDataSource
    {
        public IEnumerable<Person> Retrieve( int StartRow, int RowCount )
        {
            return DataModel.Instance.Persons.Skip( StartRow ).Take( RowCount );
        }
        public int CountItems()
        {
            return DataModel.Instance.Persons.Count;
        }
     }
