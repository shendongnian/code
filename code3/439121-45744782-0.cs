    private string _BirthDate;
    
            public Form1()
            {
                InitializeComponent();
                dateTimePicker1.MaxDate = DateTime.Now; // Ensures no future dates are set.
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                //dateTimePicker1.Checked = true;
                dateTimePicker1.CustomFormat = dateTimePicker1.CustomFormat;
                dateTimePicker1.Value = DateTime.Now;
            }
            public string BirthDate
            {
                set
                {
                    if (dateTimePicker1.Value.Date == DateTime.Today)
                    {
                        dateTimePicker1.CustomFormat = " ";
                           
                    }
                    else
                    {
                        _BirthDate = value;
                    }
                }
                get { return _BirthDate; }
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
               
               BirthDate = dateTimePicker1.Value.ToString();
            }
