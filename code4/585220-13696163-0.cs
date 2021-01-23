    public class FutureInvestments
    {
    public decimal monthlyInvestment {get;set;}
    public decimal yearlyInterestRate {get;set;}
    public decimal futureValue {get;set;}
    public decimal monthlyInterestRate {get;set;}
    public decimal monthlyInvestment {get;set;}
    
      public string Calculate()
      {
        int months = years * 12;
        monthlyInterestRate = yearlyInterestRate / 12 / 100;
        for (int i = 0; i < months; i++)
        {
         futureValue = (futureValue + monthlyInvestment)  * (1 + monthlyInterestRate);
        }
        return futureValue.ToString("c");  
      }  
    }
    public mainForm()
    {
        InitializeComponent();
    }
        
    List<FutureInvestments> summary = new List<FutureInvestments>();
    
    private void calculateButton_Click(object sender, EventArgs e)
    {
       //Instantiate class - passing in ReadOnly parameters
       var futureInv = new FutureInvestment() {monthlyInvestment = Convert.ToDecimal (monthlyInvestmentTextBox.Text), monthlyInvestment = Convert.ToDecimal(monthlyInvestmentTextBox.Text), yearlyInterestRate = Convert.ToDecimal (interestRateTextBox.Text) years =  Convert.ToInt32(yearsTextBox.Text));
             
       futureInv.Calculate();
       //Store the calculation for showing user when application closes
       summary.Add(futureInv);
     }
    private void exitButton_Click(object sender, EventArgs e)
    {
        foreach(var item in summary)
        {
            MessageBox.Show("Future value is: " + item.FutureValue.ToString());
        }
        this.Close();
    }
