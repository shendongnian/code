    public partial class Form1 : Form
    {
        private int menuStripHeight = 50;
        public Form1()
        {
            InitializeComponent();
            this.ControlAdded += Form1_ControlAdded;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MenuStrip menu = new MenuStrip();
            menu.Items.Add("File");
            menu.AutoSize = false;
            menu.Height = menuStripHeight; ;
            menu.Dock = DockStyle.Top;
            MainMenuStrip = menu;
            Controls.Add(menu);
            Button b = new Button();
            b.Text = "hello world";
            // note that the position used is 0,0
            b.SetBounds(0, 0, 128, 50);
            Controls.Add(b);
        }
        void Form1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType().FullName != "System.Windows.Forms.MenuStrip")
                e.Control.Top += menuStripHeight;
        }
    }
