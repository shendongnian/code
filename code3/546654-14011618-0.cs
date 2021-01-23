    public interface IDTOSearchField
    {
        void MapToSearchField(ISearchField searchField);
    }
    public class DTOSearchField<T> : IDTOSearchField
    {
        public T EqualTo;
        public void MapToSearchField(ISearchField searchField)
        {
            if (!(searchField is SearchField<T>))
            {
                throw new ArgumentException("SearchField must be of type " + typeof(T).FullName + ".", "searchField");
            }
            ((SearchField<T>)searchField).WhereEquals(EqualTo);
        }
    }
