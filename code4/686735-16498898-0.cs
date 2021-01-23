    // Use dependency injection to populate the service
    private AccountService accountService;
    // Not sure how you set the account - this might actually be some global state
    private long currentAccount;
    private decimal Balance { get; set; }
    private void button1_Click(object sender, EventArgs e)
    {
       int deposit=int.Parse(textBox1.Text);
       if (deposit == 0)
       {
           MessageBox.Show("Please enter a value greater than 0");
       }
       else
       {
           Account account = accountService.GetAccount(currentAccount);
           account.Deposit(deposit);
           this.Balance = account.Balance;
           MessageBox.Show("Thank you, your balance has been updated.");
       }
    }
