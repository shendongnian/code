    class Contacts : IEnumerable<Contact>
    {
        List<Contact> contacts;
        #region Implementation of IEnumerable
        public IEnumerator<Contact> GetEnumerator()
        {
            return contacts.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
