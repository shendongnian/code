    public class ComparingObservableCollection<T> : ObservableCollection<T>
         where T : IComparable<T>
    {
             
        protected override void InsertItem(int index, T item)
        {
            int i = 0;
            bool found = false;
            for (i = 0; i < Items.Count; i++)
            {
                if (item.CompareTo(Items[i]) < 0) {
                    found = true;
                    break;
                }
            }
            if (!found) i = Count;
            base.InsertItem(i, item);
        }
    }
