    public partial class Form1: Form {
        public Form1() {
            // InitializeComponent(); 
        }
        class myclass {
            private Form1 parent;
            public myclass(Form1 parent) {
                this.parent = parent;
            }
            public void DoSomething() {
                parent.textBox1.Text = "Hello, World!";
            }
        }
        public System.Windows.Forms.TextBox textBox1;
    }
