    public class Collection<T> : IList<T>, ICollection<T>, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
       {
         public void Add(T item)
         {
              if (this.items.IsReadOnly)
                ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
              this.InsertItem(this.items.Count, item);
         }
         protected virtual void InsertItem(int index, T item)
         {
              this.items.Insert(index, item);
         }     
      }
