    public partial class Form2 : Form
    {
        private Form1 f1;
        public Form2(Form1 ParentForm)
        {
            InitializeComponent();
            f1 = ParentForm;
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = f1.Test;
        }
    }
