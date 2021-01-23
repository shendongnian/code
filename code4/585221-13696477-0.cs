        public partial class mainForm : Form
    {
        private Stack<Investment> Investments;
        public mainForm()
        {
            InitializeComponent();
            Investments = new Stack<Investment>();
        }
        private void calculateButton_Click(object sender, EventArgs e)
        {
            Investment thisInvestment = new Investment(Convert.ToDecimal(monthlyInvestmentTextBox.Text),
                                                       Convert.ToDecimal(interestRateTextBox.Text),
                                                       Convert.ToInt32(yearsTextBox.Text));
            Investments.Push(thisInvestment);
            futureValueTextBox.Text = thisInvestment.futureValue.ToString("c");
            monthlyInvestmentTextBox.Focus();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            int count = Math.Min(10, Investments.Count);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= count; i++)
            {
                sb.AppendLine(Investments.Pop().ToString());
            }
            MessageBox.Show(sb.ToString());
        }
    }
    public class Investment
    {
        public Investment(decimal monthlyInvestment, decimal yearlyInterestRate, int years)
        {
            this.monthlyInvestment = monthlyInvestment;
            this.yearlyInterestRate = yearlyInterestRate;
            this.years = years;
        }
        public decimal monthlyInvestment { get; set; }
        public decimal yearlyInterestRate { get; set; }
        public decimal monthlyInterestRate
        {
            get
            {
                return yearlyInterestRate / 12 / 100;
            }
        }
        public int years { get; set; }
        public int months
        {
            get
            {
                return years * 12;
            }
        }
        public decimal futureValue
        {
            get
            {
                decimal retVal = 0;
                for (int i = 0; i < months; i++)
                {
                    retVal = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
                }
                return retVal;
            }
        }
        public override string ToString()
        {
            return string.Format("Investment of {0:c} for {1:n} years at {2:p} pa yields {3:c}", monthlyInvestment,years,monthlyInterestRate,futureValue);
        }
    }
