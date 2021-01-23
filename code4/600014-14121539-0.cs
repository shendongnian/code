    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStates.Items.Add("Andhra Pradesh");
            cmbStates.Items.Add("Tamilnadu");
            cmbStates.Items.Add("Karnataka");
            cmbStates.SelectedValue = 0;
        }
        private void cmbStates_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbStates.SelectedItem.ToString() == "Andhra Pradesh")
            {
                cmbCities.Items.Clear();
                cmbCities.Items.Add("Hyderabad");
                cmbCities.Items.Add("Guntur");
                cmbCities.Items.Add("Vijayawada");
                cmbCities.SelectedValue = 0;
                
            }
            else if (cmbStates.SelectedItem.ToString() == "Tamilnadu")
            {
                cmbCities.Items.Clear();
                cmbCities.Items.Add("Chennai");
                cmbCities.Items.Add("Coimbatore");
                cmbCities.Items.Add("ooty");
                cmbCities.SelectedValue = 0;
                
            }
            else if (cmbStates.SelectedItem.ToString() == "Karnataka")
            {
                cmbCities.Items.Clear();
                cmbCities.Items.Add("Bangalore");
                cmbCities.Items.Add("Mangalore");
                cmbCities.SelectedValue = 0;
                
            }
            else
            {
                MessageBox.Show("Please Select any value");
            }
        }
    }
}
