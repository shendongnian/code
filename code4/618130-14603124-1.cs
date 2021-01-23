    public class PhoneRepository
    {
        public List<Phone> LoadPhonesFromId(IEnumerable<int> ids)
        {
           // write a query with the ids
           // SELECT * FROM Phones WHERE id IN (@id1, @id2, ...)
           // execute the query
           // convert the results to Phones and put them in a List<Phone>
           // return the list
        }
        public List<Phone> LoadPhonesFromUserId(IEnumerable<int> userIds)
        {
           // write a query with the userIds
           // SELECT * FROM Phones WHERE userId IN (@userId1, @userId2, ...)
           // execute the query
           // convert the results to Phones and put them in a List<Phone>
           // return the list
        }
    }
