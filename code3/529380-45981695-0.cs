    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BGimplent obj = null;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
             obj = new BGimplent();
            obj.eveBG += obj_eveBG;
            i = 5;
            obj.MyProperty = 5;
            obj.DoConfig();
            obj.ManualReset.WaitOne();
            obj.MyProperty = 10;
            obj.MyProperty = 11;
            obj.MyProperty = 12;
            obj.MyProperty = 13;
            
            obj.MyProperty = 14;
        }
        void obj_eveBG(string s)
        {
            obj.ManualReset.Set();
            MessageBox.Show(s);
        }
    }
