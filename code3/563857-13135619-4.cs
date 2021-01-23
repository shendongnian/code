    class Contacts
    {
        List<Contact> contacts;
        public IEnumerator<Contact> GetEnumerator()
        {
            foreach (var contact in contacts)
                yield return contact;
        }
    }
