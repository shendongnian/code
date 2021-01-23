    public class CustomClass : IComparable<CustomClass>
    {
       public string Id { get; set; }        
       public string Name { get; set; }        
       public string CreatedDate get{ get; set; }
       public int CompareTo(CustomClass other)
       {
          return compareDate.CompareTo(other.compareDate);
       }
    }
        public class ComparingObservableCollection<T> : ObservableCollection<T> where T : IComparable<T>
        {
            protected override void InsertItem(int index, T item)
            {
                if (!Items.Contains<T>(item))
                    base.InsertItem(index, item);
            }
        }
