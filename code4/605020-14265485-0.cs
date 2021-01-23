    namespace DateTimePickerTests
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                DTPStartDate.Format = DateTimePickerFormat.Custom;
                DTPStartDate.CustomFormat = "dd/MM/yyyy";
                DTPStartDate.ShowUpDown = true;
                
                DTPEndDate.Format = DateTimePickerFormat.Custom;
                DTPEndDate.CustomFormat = "dd/MM/yyyy";
                DTPEndDate.ShowUpDown = true;
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                DateTime now = DateTime.Now;
                int result = DateTime.Compare(DTPStartDate.Value, now);
    
                if (result >= 1)
                {
                    label3.Text = "Expired";
                }
                else
                {
                    label3.Text = "Not Expired";
                }
    
              
            }
    
    
        }
    }
