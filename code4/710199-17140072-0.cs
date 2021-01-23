    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }
        protected virtual void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("From Base");
        }
    }
    public class Derived: Base
    {
        protected override void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("From Derived");
        }
    }
