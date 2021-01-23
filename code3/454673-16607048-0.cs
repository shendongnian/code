    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true;
        }
    
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: MessageBox.Show("Left");
                    break;
                case Keys.Right: MessageBox.Show("Right");
                    break;
            }
        }
    }
