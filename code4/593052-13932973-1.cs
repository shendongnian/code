    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    
    namespace ViewLayer
    {
        public class TransformObservableCollection<T,Source> : INotifyCollectionChanged, IList, IReadOnlyList<T>, IDisposable
        {
            public TransformObservableCollection(ObservableCollection<Source> wrappedCollection, Func<Source,T> transform)
            {
                m_WrappedCollection = wrappedCollection;
                m_TransformFunc = transform;
                ((INotifyCollectionChanged)m_WrappedCollection).CollectionChanged += TransformObservableCollection_CollectionChanged;
                m_TransformedCollection = new ObservableCollection<T>(m_WrappedCollection.Select(m_TransformFunc));
            }
            public void Dispose()
            {
                if (m_WrappedCollection == null) return;
                ((INotifyCollectionChanged)m_WrappedCollection).CollectionChanged -= TransformObservableCollection_CollectionChanged;
                m_WrappedCollection = null;
            }
            void TransformObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (e.NewItems == null || e.NewItems.Count != 1)
                            break;
                        m_TransformedCollection.Insert(e.NewStartingIndex,m_TransformFunc((Source)e.NewItems[0]));
                        return;
                    case NotifyCollectionChangedAction.Move:
                        if (e.NewItems == null || e.NewItems.Count != 1 || e.OldItems == null || e.OldItems.Count != 1)
                            break;
                        m_TransformedCollection.Move(e.OldStartingIndex, e.NewStartingIndex);
                        return;
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldItems == null || e.OldItems.Count != 1)
                            break;
                        m_TransformedCollection.RemoveAt(e.OldStartingIndex);
                        return;
                    case NotifyCollectionChangedAction.Replace:
                        if (e.NewItems == null || e.NewItems.Count != 1 || e.OldItems == null || e.OldItems.Count != 1 || e.OldStartingIndex != e.NewStartingIndex)
                            break;
                        m_TransformedCollection[e.OldStartingIndex] = m_TransformFunc((Source)e.NewItems[0]);
                        return;
                } // This  is most likely called on a Clear(), we don't optimize the other cases (yet)
                m_TransformedCollection.Clear();
                foreach (var item in m_WrappedCollection)
                    m_TransformedCollection.Add(m_TransformFunc(item));
            }
    
            #region IList Edit functions that are unsupported because this collection is read only
            public int Add(object value) { throw new InvalidOperationException(); }
            public void Clear() { throw new InvalidOperationException(); }
            public void Insert(int index, object value) { throw new InvalidOperationException(); }
            public void Remove(object value) { throw new InvalidOperationException(); }
            public void RemoveAt(int index) { throw new InvalidOperationException(); }
            #endregion IList Edit functions that are unsupported because this collection is read only
    
            #region Accessors
            public T this[int index] { get { return m_TransformedCollection[index]; } }
            object IList.this[int index] { get { return m_TransformedCollection[index]; } set { throw new InvalidOperationException(); } }
            public bool Contains(T value) { return m_TransformedCollection.Contains(value); }
            bool IList.Contains(object value) { return ((IList)m_TransformedCollection).Contains(value); }
            public int IndexOf(T value) { return m_TransformedCollection.IndexOf(value); }
            int IList.IndexOf(object value) { return ((IList)m_TransformedCollection).IndexOf(value); }
            public int Count { get { return m_TransformedCollection.Count; } }
            public IEnumerator<T> GetEnumerator() { return m_TransformedCollection.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)m_TransformedCollection).GetEnumerator(); }
            #endregion Accessors
    
            public bool IsFixedSize { get { return false; } }
            public bool IsReadOnly { get { return true; } }
            public void CopyTo(Array array, int index) { ((IList)m_TransformedCollection).CopyTo(array, index); }
            public void CopyTo(T[] array, int index) { m_TransformedCollection.CopyTo(array, index); }
            public bool IsSynchronized { get { return false; } }
            public object SyncRoot { get { return m_TransformedCollection; } }
    
            ObservableCollection<T> m_TransformedCollection;
            ObservableCollection<Source> m_WrappedCollection;
            Func<Source, T> m_TransformFunc;
    
            event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
            {
                add { ((INotifyCollectionChanged)m_TransformedCollection).CollectionChanged += value; }
                remove { ((INotifyCollectionChanged)m_TransformedCollection).CollectionChanged -= value; }
            }
        }
    }
