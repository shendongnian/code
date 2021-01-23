    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(example_MouseMove);
            listBox1.MouseMove += new MouseEventHandler(example_MouseMove);
            this.Shown += new EventHandler(Form1_Shown);
        }
        void Form1_Shown(object sender, EventArgs e)
        {
            _prevMousePosition = Cursor.Position;
        }
        private int counter = 0;
        private Point _prevMousePosition = new Point(0, 0);
        private void example_MouseMove(object sender, MouseEventArgs e)
        {
            if (_prevMousePosition == Cursor.Position)
            {
                counter++;
                listBox1.Items.Add(counter.ToString() + ": " + _prevMousePosition.ToString());
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            else
            {
                _prevMousePosition = Cursor.Position;
                this.Text = _prevMousePosition.ToString();
            }
        }
    }
