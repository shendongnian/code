    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        
        private List<string> _totals = new List<string>();
    
        private void btnCalculate_Click(object sender, EventArgs e)
        {
                string customerType = txtCustomerType.Text;
                decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
                decimal discountPercent = .0m;
    
                switch (customerType)
                {
                    case "R":
                        if (subtotal < 100)
                            discountPercent = .0m;
                        else if (subtotal >= 100 && subtotal < 250)
                            discountPercent = .1m;
                        else if (subtotal >= 250 && subtotal < 500)
                            discountPercent = .25m;
                        else if (subtotal >= 500)
                            discountPercent = .30m;
                        break;
                    case "C":
                        discountPercent = .2m;
                        break;
                    case "T":
                        if (subtotal < 500)
                            discountPercent = .4m;
                        else if (subtotal >= 500)
                            discountPercent = .5m;
                        break;
                    default:
                        discountPercent = .1m;
                        break;
                }
    
                decimal discountAmount = subtotal * discountPercent;
                decimal invoiceTotal = subtotal - discountAmount;
    
                txtDiscountPercent.Text = discountPercent.ToString("p1");
                txtDiscountAmount.Text = discountAmount.ToString("c");
                txtTotal.Text = invoiceTotal.ToString("c");
                _totals.Add(txtTotal.Text);
    
                txtCustomerType.Focus();
            }
    
    
            private void btnExit_Click(object sender, EventArgs e)
            {
                MessageBox.Show(string.Join(Environment.NewLine, _totals.ToArray()), "Order Totals");
                this.Close();
            }
        
    }
