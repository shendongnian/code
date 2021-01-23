    public interface IAccount
        {
            string Notes { get; set; }
            void Create();
            void Init(DateTime created, string createdBy);
        }
    public class Account : IAccount
    {
        public string Notes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void IAccount.Create()
        {
            throw new NotImplementedException();
        }
        void IAccount.Init(DateTime created, string createdBy)
        {
            throw new NotImplementedException();
        }
    }
    public class Account_Accessor : IAccount
    {
        string IAccount.Notes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void IAccount.Create()
        {
            throw new NotImplementedException();
        }
        void IAccount.Init(DateTime created, string createdBy)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        internal static void CreateAccount<T>(out T account, bool saveToDatabase) where T : IAccount,new()
        {
            DateTime created = DateTime.Now;
            string createdBy = _testUserName;
            account = new T();
            account.Init(created, createdBy);
            account = (T)Activator.CreateInstance(typeof(T), new object[] { created, createdBy });
            account.Notes = Utilities.RandomString(1000);
            if (saveToDatabase)
                account.Create();
        }
        static void Main(string[] args)
        {
            Account acc;
            Account_Accessor acc2;
            CreateAccount(out acc, false);
            CreateAccount(out acc2, false);
        }
    }
