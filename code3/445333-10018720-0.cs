      //construct
    public BankAccount()
    {
    }
    public BankAccount(string anID, string aName, int anAge, double aBalance)
    {
        AccountID = anID;
        CustomerName = aName;
        CustomerAge = anAge;
        if (abalance == 0)
        {
          Balance = DEFAULT_BALANCE;
        }
        else {
          Balance = aBalance;
        }
    }
    private string _CustomerName;
    public string CustomerName
    {
      get {
        retrun _CustomerName;
      }
      set {
       _CustomerName = value;
      }
    private string _AccountID;
    public string AccountID
    {
      get {
        retrun _AccountID;
      }
      set {
       _AccountID= value;
      }
    private string _CustomerAge;
    public string CustomerAge
    {
      get {
        retrun _CustomerAge;
      }
      set {
       _CustomerAge= value;
      }
    private string _Balance;
    public string Balance
    {
      get {
        retrun _Balance;
      }
      set {
       _Balance= value;
      }
