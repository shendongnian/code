    class Contacts : IEnumerable
    {
        List<Contact> contacts;
        #region Implementation of IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return contacts.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
