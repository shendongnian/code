    public abstract class TypedComboBox<T> : ComboBox
    {
        public TypedComboBox()
        {
            _objectCollectionProxy = new TypedObjectCollectionProxy<T>(this);
        }
        private TypedObjectCollectionProxy<T> _objectCollectionProxy;
        public ObjectCollection ObjectCollectionCollection
        {
            get { return base.Items; }
        }
        public class TypedObjectCollectionProxy<ItemType> : IList, IList<ItemType>, ICollection, ICollection<ItemType>, IEnumerable, IEnumerable<ItemType>
        {
            public ObjectCollection _objectCollection;
            private TypedComboBox<T> _owner;
            public TypedObjectCollectionProxy(TypedComboBox<T> owner)
            {
                this._owner = owner;
                this._objectCollection = owner.ObjectCollectionCollection;
            }
            /// <summary>Gets the number of items in the collection</summary>
            public int Count { get { return _objectCollection.Count; } }
            /// <summary>Gets a value indicating whether this collection can be modified</summary>
            public bool IsReadOnly { get { return _objectCollection.IsReadOnly; } }
            /// <summary>Retrieves the item at the specified index within the collection</summary>
            /// <param name="index">The index of the item in the collection to retrieve</param>
            /// <returns>An object representing the item located at the specified index within the collection</returns>
            /// <exception cref="System.ArgumentOutOfRangeException">The index was less than zero.-or- The index was greater than the count of
            ///                                                          items in the collection.</exception>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public virtual ItemType this[int index]
            {
                get
                {
                    CheckItems();
                    return (ItemType)_objectCollection[index];
                }
                set
                {
                    CheckItems();
                    _objectCollection[index] = value;
                }
            }
            public void CheckItems()
            {
                if (this._objectCollection != _owner.ObjectCollectionCollection)
                    this._objectCollection = _owner.ObjectCollectionCollection;
            }
            /// <summary>Adds an item to the list of items for a System.Windows.Forms.ComboBox</summary>
            /// <param name="item">An object representing the item to add to the collection</param>
            /// <returns>The zero-based index of the item in the collection</returns>
            /// <exception cref="System.ArgumentNullException">The item parameter was null</exception>
            public int Add(ItemType item)
            {
                CheckItems();
                return _objectCollection.Add(item);
            }
            /// <summary>Adds an array of items to the list of items for a System.Windows.Forms.ComboBox</summary>
            /// <param name="items">An array of objects to add to the list</param>
            /// <exception cref="System.ArgumentNullException">An item in the items parameter was null</exception>
            public void AddRange(IEnumerable<ItemType> items)
            {
                CheckItems();
                _objectCollection.AddRange(items.Cast<object>().ToArray());
            }
            /// <summary>Removes all items from the System.Windows.Forms.ComboBox</summary>
            public void Clear()
            {
                CheckItems();
                _objectCollection.Clear();
            }
            /// <summary>Determines if the specified item is located within the collection</summary>
            /// <param name="value">An object representing the item to locate in the collection</param>
            /// <returns>true if the item is located within the collection; otherwise, false</returns>
            public bool Contains(ItemType value)
            {
                CheckItems();
                return _objectCollection.Contains(value);
            }
            /// <summary>Copies the entire collection into an existing array of objects at a specified location within the array</summary>
            /// <param name="destination">The object array to copy the collection to</param>
            /// <param name="arrayIndex">The location in the destination array to copy the collection to</param>
            public void CopyTo(object[] destination, int arrayIndex)
            {
                CheckItems();
                _objectCollection.CopyTo(destination, arrayIndex);
            }
            /// <summary>Returns an enumerator that can be used to iterate through the item collection</summary>
            /// <returns>An System.Collections.IEnumerator that represents the item collection</returns>
            public IEnumerator GetEnumerator()
            {
                CheckItems();
                return _objectCollection.GetEnumerator();
            }
            /// <summary>Retrieves the index within the collection of the specified item</summary>
            /// <param name="value">An object representing the item to locate in the collection</param>
            /// <returns>The zero-based index where the item is located within the collection; otherwise, -1</returns>
            /// <exception cref="System.ArgumentNullException">The value parameter was null</exception>
            public int IndexOf(ItemType value)
            {
                CheckItems();
                return _objectCollection.IndexOf(value);
            }
            /// <summary>Inserts an item into the collection at the specified index</summary>
            /// <param name="index">The zero-based index location where the item is inserted</param>
            /// <param name="item">An object representing the item to insert</param>
            /// <exception cref="System.ArgumentNullException">The item was null</exception>
            /// <exception cref="System.ArgumentOutOfRangeException">The index was less than zero.-or- The index was greater than the count of items in the collection</exception>
            public void Insert(int index, ItemType item)
            {
                CheckItems();
                _objectCollection.Insert(index, item);
            }
            /// <summary>Removes the specified item from the System.Windows.Forms.ComboBox</summary>
            /// <param name="value">The System.Object to remove from the list</param>
            public bool Remove(ItemType value)
            {
                int kIndex = IndexOf(value);
                if (kIndex >= 0)
                {
                    CheckItems();
                    _objectCollection.RemoveAt(kIndex);
                    return true;
                }
                return false;
            }
            /// <summary>Removes an item from the System.Windows.Forms.ComboBox at the specified index</summary>
            /// <param name="index">The index of the item to remove</param>
            /// <exception cref="System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection</exception>
            public void RemoveAt(int index)
            {
                CheckItems();
                _objectCollection.RemoveAt(index);
            }
            #region IList Members
            int IList.Add(object value)
            {
                return this.Add((ItemType)value);
            }
            void IList.Clear()
            {
                this.Clear();
            }
            bool IList.Contains(object value)
            {
                return this.Contains((ItemType)value);
            }
            int IList.IndexOf(object value)
            {
                return this.IndexOf((ItemType)value);
            }
            void IList.Insert(int index, object value)
            {
                this.Insert(index, (ItemType)value);
            }
            bool IList.IsFixedSize
            {
                get
                {
                    CheckItems();
                    return (_objectCollection as IList).IsFixedSize;
                }
            }
            bool IList.IsReadOnly
            {
                get { return this.IsReadOnly; }
            }
            void IList.Remove(object value)
            {
                this.Remove((ItemType)value);
            }
            void IList.RemoveAt(int index)
            {
                this.RemoveAt(index);
            }
            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    this[index] = (ItemType)value;
                }
            }
            #endregion
            #region ICollection Members
            void ICollection.CopyTo(Array array, int index)
            {
                this.CopyTo((object[])array, index);
            }
            int ICollection.Count
            {
                get { return this.Count; }
            }
            bool ICollection.IsSynchronized
            {
                get
                {
                    CheckItems();
                    return (_objectCollection as ICollection).IsSynchronized;
                }
            }
            object ICollection.SyncRoot
            {
                get
                {
                    CheckItems();
                    return (_objectCollection as ICollection).SyncRoot;
                }
            }
            #endregion
            #region IEnumerable<ItemType> Members
            IEnumerator<ItemType> IEnumerable<ItemType>.GetEnumerator()
            {
                CheckItems();
                return _objectCollection.Cast<ItemType>().GetEnumerator();
            }
            #endregion
            #region ICollection<ItemType> Members
            void ICollection<ItemType>.Add(ItemType item)
            {
                this.Add(item);
            }
            void ICollection<ItemType>.Clear()
            {
                this.Clear();
            }
            bool ICollection<ItemType>.Contains(ItemType item)
            {
                return this.Contains(item);
            }
            void ICollection<ItemType>.CopyTo(ItemType[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }
            int ICollection<ItemType>.Count
            {
                get { return this.Count; }
            }
            bool ICollection<ItemType>.IsReadOnly
            {
                get { return this.IsReadOnly; }
            }
            bool ICollection<ItemType>.Remove(ItemType item)
            {
                return this.Remove(item);
            }
            #endregion
            #region IEnumerable Members
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            #endregion
        }
        /// <summary>Gets an object representing the collection of the items contained in this System.Windows.Forms.ComboBox</summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Bindable(true)]
        public new TypedObjectCollectionProxy<T> Items
        {
            get { return _objectCollectionProxy; }
        }
        /// <summary>Gets or sets currently selected item in the System.Windows.Forms.ComboBox</summary>
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new T SelectedItem
        {
            get { return (T)base.SelectedItem; }
            set { base.SelectedItem = value; }
        }
    }
