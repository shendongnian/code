        // this is by passing the reference of the form to other form
        public partial class Form4 : Form
    
        {
        
        public int a { get; set; }
        public int b { get; set; }
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            a = 5;
            b = 6;
            Form5 frm5 = new Form5();
            frm5.frm4 = this;
            this.Close();
            frm5.Show();
        }
         }
        // code on form5
        public Form4 frm4 { get; set; }
        private void Form5_Load(object sender, EventArgs e)
        {
            int x = frm4.a;
            int y = frm4.b;
        }
