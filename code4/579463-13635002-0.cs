    public partial class Form1 : Form {
        private CheckBox[] checkboxes;
        private char[] operators;
        public Form1() {
            InitializeComponent();
            checkboxes = new[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            checkBox1.Tag = '+';
            checkBox2.Tag = '-';
            checkBox3.Tag = '*';
            checkBox4.Tag = '/';
            checkBox5.Tag = '%';
            foreach (var cb in checkboxes) {
                cb.CheckedChanged += cb_CheckedChanged;
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e) {
            operators = checkboxes.Where(cb => cb.Checked).Select(cb => cb.Tag).Cast<char>().ToArray();
        }
    }
