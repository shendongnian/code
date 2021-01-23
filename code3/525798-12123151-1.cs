    public partial class Form1 : Form
    {
        private UserControl1 uc1 = new UserControl1();
        private UserControl2 uc2 = new UserControl2();
        private UserControl3 uc3 = new UserControl3();
        public Form1()
        {
            InitializeComponent();
            AssignedButtonClickEvents();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        protected void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            panel1.Controls.Clear();
            if (button != null)
            {
                switch (button.Name)
                {
                    case "button1":
                        uc1.Dock = DockStyle.Fill;
                        panel1.Controls.Add(uc1);
                        break;
                    case "button2":
                        uc2.Dock = DockStyle.Fill;
                        panel1.Controls.Add(uc2);
                        break;
                    case "button3":
                        uc3.Dock = DockStyle.Fill;
                        panel1.Controls.Add(uc3);
                        break;
                    default:
                        panel1.Controls.Clear();
                        break;
                }
            }
        }
        public void AssignedButtonClickEvents()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is Button)
                {
                    Button button = (Button)ctl;
                    button.Click += new EventHandler(ButtonClicked);
                }
            }
        }
