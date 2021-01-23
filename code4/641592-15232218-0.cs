    public partial class Form1 : Form
    {
        private int[] vars;
        public Form1()
        {
            InitializeComponent();
            vars = new int[5];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] tmp = new int[vars.Length + 1];
            vars.CopyTo(tmp, 0);
            vars = tmp;
        }
    }
