    public partial class Form1 : Form
    {
        ComboBox _dummy;
        public Form1()
        {
            InitializeComponent();
            // set the style
            comboBox1.DropDownStyle = 
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            // disable the combobox
            comboBox1.Enabled = false;
            // add the dummy combobox
            _dummy = new ComboBox();
            _dummy.Visible = false;
            _dummy.Enabled = true;
            _dummy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(_dummy);
            // add the event handler
            MouseMove += Form1_MouseMove;
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            var child = this.GetChildAtPoint(e.Location);
            if (child == comboBox1)
            {
                if (!comboBox1.Enabled)
                {
                    // copy the items
                    _dummy.Items.Clear();
                    object[] items = new object[comboBox1.Items.Count];
                    comboBox1.Items.CopyTo(items, 0);
                    _dummy.Items.AddRange(items);
                    // set the size and position
                    _dummy.Left = comboBox1.Left;
                    _dummy.Top = comboBox1.Top;
                    _dummy.Height = comboBox1.Height;
                    _dummy.Width = comboBox1.Width;
                    // switch visibility
                    comboBox1.Visible = !(_dummy.Visible = true);
                }
            }
            else if (child != _dummy)
            {
                // switch visibility
                comboBox1.Visible = !(_dummy.Visible = false);
            }
        }
    }
