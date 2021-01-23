    public partial class ControlPlayerParams : UserControl {
        public string Param1 { get { return this.textBox1.Text; } }
        public string Param2 { get { return this.textBox2.Text; } }
        public string Param3 { get { return this.textBox3.Text; } }
        public ControlPlayerParams() {
            this.InitializeComponent();
        }
    }
