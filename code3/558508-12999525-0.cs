    public abstract class BaseAccount
    {
        public string Notes;
        public virtual void Create() { ... }
    }
    public class Account : BaseAccount { ... }
    public class Account_Accessor : BaseAccount { ... }
    internal static void CreateAccount<T>(out T account, bool saveToDatabase) where T : BaseAccount
    {
        DateTime created = DateTime.Now;
        string createdBy = _testUserName;
        account = (T)Activator.CreateInstance(typeof(T), new object[] { created, createdBy });
        account.Notes = Utilities.RandomString(1000);
        if (saveToDatabase)
            account.Create();
    }
