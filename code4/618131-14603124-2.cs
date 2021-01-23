    public class UserRepository
    {
        public List<User> LoadUsersFromUserIds(IEnumerable<int> userIds)
        {
           // write a query with the userIds
           // SELECT * FROM User WHERE id IN (@id1, @id2, ...)
           // execute the query
           // convert the results to Users and put them in a List<User>
           // return the list
        }
        public void IncludePhones(IEnumerable<User> users)
        {            
            var phones = PhoneRepository.LoadPhonesFromUserId
                (users.Select(x => x.Id));
            for each(var user in users)
            {
                user.Phones = phones
                    .Where(x => x.UserId == user.Id)
                    .ToList();
            }
        }
    }
