    public class Contacts: IEnumerable
    {
         ...... 
        public IEnumerator GetEnumerator()
        {
            return contacts.GetEnumerator();
        }
    }
