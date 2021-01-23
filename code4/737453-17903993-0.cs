    public partial class Form1 : Form
    {
        // Declare a couple of properties for receiving the numbers
        public double ub_s { get; set; }
        public double poj_s { get; set; }   // I'll cut all other fields for simplicity
    
        public Form1()
        {
            InitializeComponent();
    
            // Bind each TextBox with its backing variable
            this.p_ub_s.DataBindings.Add("Text", this, "ub_s");
            this.p_poj_s.DataBindings.Add("Text", this, "poj_s");
        }
        // Here comes your code, with a little modification
        private void vypocti_naklady()
        {
           if (this.ub_s == 0 || this.poj_s == 0 /*.......*/)
           {
               naklady.Text = "0";
               return;
           }
           naklady.Text = (this.ub_s + this.poj_s).ToString();
        }
    }
