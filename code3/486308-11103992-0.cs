    namespace myNameSpace
    {
        public static class LinqExtensions
        {
           public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> _LinqResult)
           {
              return new ObservableCollection<T>(_LinqResult);              
           }
        }
    }
