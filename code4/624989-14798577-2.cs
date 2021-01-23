    public class Bank : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BindingList<Customer> customers = new BindingList<Customer>();
        public int Worth
        {
            get { return customers.Sum(cust => cust.FullBalance); }
        }
        public Bank()
        {
            customers.ListChanged += new ListChangedEventHandler(customers_ListChanged);
        }
        void customers_ListChanged(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine("A customer has changed.");
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs("Worth"));
        }
        public void Add(Customer c) { customers.Add(c); }
    }
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BindingList<Account> accounts = new BindingList<Account>();
        public int FullBalance
        {
            get { return accounts.Sum(acc => acc.Balance); }
        }
        public Customer()
        {
            accounts.ListChanged += new ListChangedEventHandler(accounts_ListChanged);
        }
        void accounts_ListChanged(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine("An account has changed.");
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs("FullBalance"));
        }
        public void Add(Account a) { accounts.Add(a); }
    }
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int balance = 0;
        public int Balance
        {
            get { return balance; }
            set
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs("Balance"));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account() { Balance = 5 };
            Account a2 = new Account() { Balance = 10 };
            Account a3 = new Account() { Balance = 15 };
            Customer c1 = new Customer(); c1.Add(a1); c1.Add(a2);
            Customer c2 = new Customer(); c2.Add(a3);
            Bank b = new Bank(); b.Add(c1); b.Add(c2);
            Console.WriteLine();
            a1.Balance += 100;
        }
    }
