    namespace PresentationModel
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Collections.Specialized;
        using System.ComponentModel;
        using System.Linq;
        using System.Windows.Data;
        public class GroupViewItem : IList, INotifyCollectionChanged
        {
            private readonly CollectionViewGroup group;
            public GroupViewItem(CollectionViewGroup group)
            {
                this.group = group;
                ((INotifyCollectionChanged)this.group.Items).CollectionChanged += HandleCollectionViewGroupChanged;
            }
            private void HandleCollectionViewGroupChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                OnCollectionChanged(e);
            }
            public object Name { get { return this.group.Name; } }
            public int Count { get { return this.group.ItemCount; } }
            public IEnumerator GetEnumerator()
            {
                return this.group.Items.GetEnumerator();
            }
            public event NotifyCollectionChangedEventHandler CollectionChanged;
            private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
            {
                var collectionChanged = this.CollectionChanged;
                if (collectionChanged != null)
                {
                    collectionChanged(this, args);
                }
            }
            int IList.Add(object value)
            {
                throw new NotSupportedException();
            }
            void IList.Clear()
            {
                throw new NotSupportedException();
            }
            bool IList.Contains(object value)
            {
                throw new NotSupportedException();
            }
            int IList.IndexOf(object value)
            {
                throw new NotSupportedException();
            }
            void IList.Insert(int index, object value)
            {
                throw new NotSupportedException();
            }
            bool IList.IsFixedSize
            {
                get
                {
                    throw new NotSupportedException();
                }
            }
            bool IList.IsReadOnly
            {
                get
                {
                    throw new NotSupportedException();
                }
            }
            void IList.Remove(object value)
            {
                throw new NotSupportedException();
            }
            void IList.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }
            object IList.this[int index]
            {
                get
                {
                    throw new NotSupportedException();
                }
                set
                {
                    throw new NotSupportedException();
                }
            }
            void ICollection.CopyTo(System.Array array, int index)
            {
                throw new NotSupportedException();
            }
            bool ICollection.IsSynchronized
            {
                get
                {
                    throw new NotSupportedException();
                }
            }
            object ICollection.SyncRoot
            {
                get
                {
                    throw new NotSupportedException();
                }
            }
        }
        public class GroupView : IEnumerable, INotifyCollectionChanged
        {
            private readonly ICollectionView collectionView;
            private readonly List<GroupViewItem> items;
            public GroupView(ICollectionView collectionView)
            {
                this.items = new List<GroupViewItem>();
                this.collectionView = collectionView;
                ((INotifyCollectionChanged)this.collectionView.Groups).CollectionChanged += HandleCollectionViewGroupsChanged;
                ResetGroups(notify: false);
            }
            private void HandleCollectionViewGroupsChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        AddGroups(e);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        RemoveGroups(e);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        ReplaceGroups(e);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        ResetGroups();
                        break;
                }
            }
            private IList<GroupViewItem> AddGroups(NotifyCollectionChangedEventArgs e, bool notify = true)
            {
                var newGroups = e.NewItems
                    .Cast<CollectionViewGroup>()
                    .Select(cvg => new GroupViewItem(cvg))
                    .ToArray();
                this.items.InsertRange(e.NewStartingIndex, newGroups);
                if (notify)
                {
                    for (var i = 0; i != newGroups.Length; ++i)
                    {
                        OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                            NotifyCollectionChangedAction.Add,
                            newGroups[i],
                            e.NewStartingIndex + i));
                    }
                }
                return newGroups;
            }
            private IList<GroupViewItem> RemoveGroups(NotifyCollectionChangedEventArgs e, bool notify = true)
            {
                var oldGroups = this.items.GetRange(e.OldStartingIndex, e.OldItems.Count);
                this.items.RemoveRange(e.OldStartingIndex, e.OldItems.Count);
                if (notify)
                {
                    for (var i = 0; i != oldGroups.Count; ++i)
                    {
                        OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                            NotifyCollectionChangedAction.Remove,
                            oldGroups[i],
                            e.OldStartingIndex + i));
                    }
                }
                return oldGroups;
            }
            private void ReplaceGroups(NotifyCollectionChangedEventArgs e)
            {
                var oldGroups = RemoveGroups(e, notify: false);
                var newGroups = AddGroups(e, notify: false);
                if (oldGroups.Count != newGroups.Count)
                {
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Reset));
                }
                else
                {
                    for (var i = 0; i != newGroups.Count; ++i)
                    {
                        OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                            NotifyCollectionChangedAction.Replace,
                            newGroups[i], oldGroups[i],
                            e.NewStartingIndex + i));
                    }
                }
            }
            private void ResetGroups(bool notify = true)
            {
                this.items.Clear();
                this.items.AddRange(
                    this.collectionView.Groups
                        .Cast<CollectionViewGroup>()
                        .Select(cvg => new GroupViewItem(cvg)));
                if (notify)
                {
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Reset));
                }
            }
            public event NotifyCollectionChangedEventHandler CollectionChanged;
            public IEnumerator GetEnumerator()
            {
                return this.items.GetEnumerator();
            }
            private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
            {
                var collectionChanged = this.CollectionChanged;
                if (collectionChanged != null)
                {
                    collectionChanged(this, args);
                }
            }
        }
    }
