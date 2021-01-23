    public struct DCM_INFO
    {
        public string FILE_NAME;
        public string FILE_PATH;
        public string VERSION;
        public string NAME;
        public string DATE;
        public string BOX;
        public string SERIAL_NUM;
        public string SERIES;
        public string POINT;
        public string NOTE;
        public string VARIANT;
        public override string ToString()
        {
            return FILE_NAME;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem != null)
            {
                DCM_INFO item = (DCM_INFO)this.comboBox1.SelectedItem;
                // Create ListViewItems and add them to ListView
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult ret = ofd.ShowDialog();
            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                
                DCM_INFO tmp = new DCM_INFO();
                // read file and fill struct
                this.comboBox1.Items.Add(tmp);
            }
        }
    }
