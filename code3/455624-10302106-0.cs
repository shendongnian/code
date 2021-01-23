    public partial class Form1 : System.Windows.Forms.Form {
        public Form1(ExternalCommandData commandData) {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            List<string> data = new List<string>();
            string line;
            StreamReader file = new StreamReader(@"C:\test.txt");
            while ((line = file.ReadLine()) != null) {
                data.Add(line);
            }
            file.Close();
            Form2 form2 = new Form2(data);
            form2.Show();
        }
    }
    public partial class Form2 : System.Windows.Forms.Form {
        public Form2(List<string> formdata) {
            InitializeComponent();
            if (formdata != null) {
                this.checkedListBox1.Items.AddRange(formdata.ToArray());
            }
        }
    }
