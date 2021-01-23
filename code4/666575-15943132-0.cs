    public class UsersIndex: AbstractIndexCreationTask<User>
    {
        public UsersIndex()
        {
            Map = docs=> from doc in docs
                         select new 
                         { 
                             DeviceIds = doc.Devices.Select(x => x.Id)
                         };
        }
    }
    var device = DbSession.Advanced.LuceneQuery<User, UsersIndex>()
                          .WhereEquals("DeviceIds", 123)
                          .Select(x => x.Devices.SingleOrDefault(d => d.Id == 123));
