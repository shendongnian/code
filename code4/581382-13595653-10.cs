    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Map.Get<MouseEventArgs>()["1"] = Form1_fooEvent1;
            Map.Get<KeyEventArgs>()["2"] = Form1_fooEvent2;
            Service s = new Service();
            s.fooEvent1 += Map.Get<MouseEventArgs>()["1"];
            s.fooEvent2 += Map.Get<KeyEventArgs>()["2"];
            s.Fire();
        }
        void Form1_fooEvent2(object sender, KeyEventArgs e)
        {
            textBox2.Text = "Form1_fooEvent2";
        }
        void Form1_fooEvent1(object sender, MouseEventArgs e)
        {
            textBox1.Text = "Form1_fooEvent1";
        }
    }
