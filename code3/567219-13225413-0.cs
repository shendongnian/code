    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();
            new Form2() { Form1 = mainForm }.Show();
            Application.Run(mainForm);
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form1 Form1 { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Form1.Update("World");
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Update("Hello");
        }
        public void Update(string text)
        {
            this.label1.Text = text;
        }
    }
