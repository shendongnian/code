    public partial class Filter : Window
    {
        public Filter()
        {
            List<FilterA> listA = new List<FilterA>();
            this.SetList<FilterA>(listA);
            this.DisplayList<FilterA>();
        }
        public interface IFilterableType { string Name { get; } }
        public class FilterA : IFilterableType { public string Name { get { return "A"; } } }
        public class FilterB : IFilterableType { public string Name { get { return "B"; } } }
        private object _myList;
        private Type _type;
        public void SetList<T>(List<T> list) where T : IFilterableType
        {
            this._myList = list;
            this._type = typeof(T);
        }
        public void DisplayList<T>() where T : IFilterableType
        {
            if (this._myList is List<T>)
                this.DataContext = (List<T>)this._myList;
            else
                throw new ArgumentException();
        }
    }
