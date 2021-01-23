    public partial class Form1 : Form
    {
        Func<string, string> doThis;
    
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }
    
        void Form1_Shown(object sender, EventArgs e)
        {
            doThis = do1;
            Text = doThis("a");
            doThis = do2;
            Text = doThis("a");
        }
    
        string do1(string s)
        {
            MessageBox.Show(s);
            return "1";
        }
    
        string do2(string s)
        {
            MessageBox.Show(s);
            return "2";
        }
    }
