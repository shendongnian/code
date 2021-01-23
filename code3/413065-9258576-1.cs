    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseHover += new EventHandler(MouseHoverEvent);
            this.MouseLeave +=new EventHandler(MouseLeaveEvent);
            timer1.Tick += new EventHandler(timer1_Tick);
            foreach (Control item in this.Controls)
            {
                item.MouseEnter += new EventHandler(MouseHoverEvent);
                item.MouseLeave += new EventHandler(MouseLeaveEvent);
            }
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            DoubleClickEvent();
        }
        void MouseLeaveEvent(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        void MouseHoverEvent(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
