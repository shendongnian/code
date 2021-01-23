    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.GotFocus += (s, e) =>
                {
                    this.textBox2.Focus();
                };
        }
    }
