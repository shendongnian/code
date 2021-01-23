    public Form1()
            {
                InitializeComponent();
                dataGridView1.MultiSelect = false;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                List<string> Mon = new List<string>() { "January", "February", "March", "April", "May", " June", "July", "August", "September", "October", "November", "December" };
                List<string> Year = new List<string>() { "2001", "2002", "2003", "2004", "2005", "2006" };
                List<Data> _Data = new List<Data>();
                for (int i = 1; i <= 12; i++)
                {
                    _Data.Add(new Data() { Mon = Mon, Year = Year });
                }
                DataGridViewComboBoxColumn moonCmb = new DataGridViewComboBoxColumn();
                moonCmb.HeaderText = "Month";
                moonCmb.Name = "Month";
                moonCmb.DataSource = Mon;
    
                DataGridViewComboBoxColumn yearCmb = new DataGridViewComboBoxColumn();
                yearCmb.HeaderText = "Year";
                yearCmb.Name = "Year";
                yearCmb.DataSource = Year;
                DataGridViewTextBoxColumn amount = new DataGridViewTextBoxColumn();
                amount.HeaderText = "Amount";
                amount.Name = "Amount";
                dataGridView1.Columns.AddRange(moonCmb, yearCmb, amount);
    
                dataGridView1.DataSource = _Data;
    
            }
    
            private void GetCurrentRowValues()
            {
                var mon = dataGridView1.CurrentRow.Cells["Month"].Value;
                var year = dataGridView1.CurrentRow.Cells["Year"].Value;
                var amont = dataGridView1.CurrentRow.Cells["Amount"].Value;
            }
    
        }
        public struct Data
        {
            public List<string> Mon { get; set; }
            public List<string> Year { get; set; }
        }
