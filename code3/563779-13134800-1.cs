    public class NotifiableConcurrentBag<T> : INotifiableConcurrentBag<T>
    {
        private readonly ConcurrentBag<T> _concurrentBag;
        public NotifiableConcurrentBag()
        {
            _concurrentBag = new ConcurrentBag<T>();
        }
        public NotifiableConcurrentBag(IEnumerable<T> collection)
        {
            _concurrentBag = new ConcurrentBag<T>(collection);
        }
        #region Implementation of IEnumerable
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (((ICollection)this).SyncRoot)
            {
                return ((IEnumerable)_concurrentBag).GetEnumerator();
            }
        }
        #endregion
        #region Implementation of IEnumerable<T>
        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </summary>
        /// <returns>
        /// An enumerator for the contents of the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            lock (((ICollection)this).SyncRoot)
            {
                return ((IEnumerable<T>)_concurrentBag).GetEnumerator();
            }
        }
        #endregion
        #region Implementation of ICollection
        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing. </param><param name="index">The zero-based index in <paramref name="array"/> at which copying begins. </param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero. </exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.-or-The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception><filterpriority>2</filterpriority>
        void ICollection.CopyTo(Array array, int index)
        {
            lock (((ICollection)this).SyncRoot)
            {
                ((ICollection)_concurrentBag).CopyTo(array, index);
            }
        }
        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </returns>
        int ICollection.Count
        {
            get
            {
                lock (((ICollection)this).SyncRoot)
                {
                    return _concurrentBag.Count;
                }
            }
        }
        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <returns>
        /// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        object ICollection.SyncRoot
        {
            get { return ((ICollection)_concurrentBag).SyncRoot; }
        }
        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <returns>
        /// true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        bool ICollection.IsSynchronized
        {
            get { return ((ICollection)_concurrentBag).IsSynchronized; }
        }
        #endregion
        #region Implementation of IConcurrentBag<T>
        /// <summary>
        /// Adds an object to the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </summary>
        /// <param name="item">The object to be added to the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        void IConcurrentBag<T>.Add(T item)
        {
            lock (((ICollection)this).SyncRoot)
            {
                _concurrentBag.Add(item);
                // TODO: Implement notification!
            }
        }
        /// <summary>
        /// Attempts to return an object from the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> without removing it.
        /// </summary>
        /// <returns>
        /// true if and object was returned successfully; otherwise, false.
        /// </returns>
        /// <param name="result">When this method returns, <paramref name="result"/> contains an object from the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> or the default value of <paramref name="T"/> if the operation failed.</param>
        bool IConcurrentBag<T>.TryPeek(out T result)
        {
            lock (((ICollection)this).SyncRoot)
            {
                return _concurrentBag.TryPeek(out result);
            }
        }
        /// <summary>
        /// Gets a value that indicates whether the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> is empty.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> is empty; otherwise, false.
        /// </returns>
        bool IConcurrentBag<T>.IsEmpty
        {
            get
            {
                lock (((ICollection)this).SyncRoot)
                {
                    return _concurrentBag.IsEmpty;
                }
            }
        }
        #endregion
        #region Implementation of IProducerConsumerCollection<T>
        /// <summary>
        /// Attempts to remove and return an object from the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </summary>
        /// <returns>
        /// true if an object was removed successfully; otherwise, false.
        /// </returns>
        /// <param name="result">When this method returns, <paramref name="result"/> contains the object removed from the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> or the default value of <paramref name="T"/> if the bag is empty.</param>
        bool IProducerConsumerCollection<T>.TryTake(out T result)
        {
            lock (((ICollection)this).SyncRoot)
            {
                bool takeResult = _concurrentBag.TryTake(out result);
                if (takeResult)
                {
                    // TODO: Implement notification!
                }
                return takeResult;
            }
        }
        /// <summary>
        /// Copies the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> elements to an existing one-dimensional <see cref="T:System.Array"/>, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> is equal to or greater than the length of the <paramref name="array"/> -or- the number of elements in the source <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.</exception>
        void IProducerConsumerCollection<T>.CopyTo(T[] array, int index)
        {
            lock (((ICollection)this).SyncRoot)
            {
                _concurrentBag.CopyTo(array, index);
            }
        }
        /// <summary>
        /// Copies the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/> elements to a new array.
        /// </summary>
        /// <returns>
        /// A new array containing a snapshot of elements copied from the <see cref="T:System.Collections.Concurrent.ConcurrentBag`1"/>.
        /// </returns>
        T[] IProducerConsumerCollection<T>.ToArray()
        {
            lock (((ICollection)this).SyncRoot)
            {
                return _concurrentBag.ToArray();
            }
        }
        /// <summary>
        /// Attempts to add an object to the <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if the object was added successfully; otherwise, false.
        /// </returns>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Concurrent.IProducerConsumerCollection`1"/>.</param><exception cref="T:System.ArgumentException">The <paramref name="item"/> was invalid for this collection.</exception>
        bool IProducerConsumerCollection<T>.TryAdd(T item)
        {
            lock (((ICollection)this).SyncRoot)
            {
                bool addResult = ((IProducerConsumerCollection<T>)_concurrentBag).TryAdd(item);
                if (addResult)
                {
                    // TODO: Implement notification!
                }
                return addResult;
            }
        }
        #endregion
        #region Implementation of INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
    }
