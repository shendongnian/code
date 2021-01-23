    public partial class MyItemForm : Form
    {
        public myItemForm(string item, double costs, int time, string picturepath)
        {
            InitializeComponent();
            label1.Text = item+ ": 1 Celsius Cost: $"+costs.ToString()+" Delivery: Within "+time.toString() +" hours."
            pictureBox1.ImageLocation = picturepath;
        }
    }
