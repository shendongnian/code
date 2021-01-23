    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            lb.Items.Add("12341','2341");
            lb.Items.Add("123415','112341");
            lb.Items.Add("543225','11234134");
        }
        private void button1_Click(object sender, EventArgs e) {
            for (int i = 0; i < lb.Items.Count; i++) {
                string item = lb.Items[i] as string;
                item = item.Substring(item.LastIndexOf("','"));
                lb.Items[i] = item;
            }
        }
    }
