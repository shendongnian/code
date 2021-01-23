    public partial class Form1 : Form
    {
        private Button[] m_ButtonsArray;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m_ButtonsArray = new Button[5];
            for (int i = 0; i < 5; i++)
            {
                m_ButtonsArray [i] = new Button();
                m_ButtonsArray [i].Width = 50;
                m_ButtonsArray [i].Height = 50;
                flowLayoutPanel1.Controls.Add(m_ButtonsArray [i]);
                m_ButtonsArray [i].Click += new EventHandler(btn_Click);
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            m_ButtonsArray[3].Text = "button name changed";  // here problems occurs
        }
    }
