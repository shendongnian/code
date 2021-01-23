    public class Account
    {
        public int Id { get; set;  }
    }
    [Route("/AllAccounts")]
    [DataContract]
    public class AllAccounts : IReturn<List<Account>>
    {
        public AllAccounts()
        {
        }
    }
    [Route("/AccountTest")]
    [DataContract]
    public class AccountTest : IReturn<string>
    {
        public AccountTest()
        {
            this.Id = 4;
        }
        [DataMember]
        public int Id { get; set; }
    }
