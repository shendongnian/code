    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e) {
            // Set breakpoint here:
            base.OnHandleCreated(e);
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            this.ShowInTaskbar = !this.ShowInTaskbar;
            MessageBox.Show(string.Format("There are {0} open forms", Application.OpenForms.Count));
            Application.Exit();
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            MessageBox.Show("you won't see this");
            base.OnFormClosing(e);
        }
    }
