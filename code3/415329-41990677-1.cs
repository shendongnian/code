    public class AccountsRepository : BaseRepository
    {
        public Account GetById(int id)
        {
            return QueryFirstOrDefault<Account>("SELECT * FROM Accounts WHERE Id = @Id", new { id });
        }
        public List<Account> GetAll()
        {
            return Query<Account>("SELECT * FROM Accounts ORDER BY Name");
        }
        // Other methods...
    }
