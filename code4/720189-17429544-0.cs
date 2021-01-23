    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyApplicationContext());
        }
    }
    public class MyApplicationContext : ApplicationContext
    {
        public MyApplicationContext()
        {
            ShowForm1();
        }
        public void ShowForm1()
        {
            if (_form2 != null)
                _form2.Hide();
            if (_form1 == null)
            {
                _form1 = new Form1(this);
                _form1.FormClosed += OnFormClosed;
            }
            _form1.Show();
            MainForm = _form1;
        }
        public void ShowForm2()
        {
            if (_form1 != null)
                _form1.Hide();
            if (_form2 == null)
            {
                _form2 = new Form2(this);
                _form2.FormClosed += OnFormClosed;
            }
            _form2.Show();
            MainForm = _form2;
        }
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_form1 != null)
            {
                _form1.Dispose();
                _form1 = null;
            }
            if (_form2 != null)
            {
                _form2.Dispose();
                _form2 = null;
            }
            ExitThread();
        }
        private Form1 _form1;
        private Form2 _form2;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(MyApplicationContext context)
            : this()
        {
            _context = context;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_context != null)
                _context.ShowForm2();
        }
        private readonly MyApplicationContext _context;
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(MyApplicationContext context)
            : this()
        {
            _context = context;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_context != null)
                _context.ShowForm1();
        }
        private readonly MyApplicationContext _context;
    }
