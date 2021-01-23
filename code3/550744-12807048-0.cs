    public partial class Form1 : Form
    {
        private TableLayoutPanel panel;
        public Form1()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AddControl(0, 0);
            AddControl(0, 1);
            AddControl(1, 0);
            AddControl(1, 1);
            AddControl(2, 0);
            AddControl(2, 1);
            AddControl(3, 0);
            AddControl(3, 1);
        }
        private void InitializeTableLayoutPanel()
        {
            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.AutoSize = true;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panel.ColumnCount = 2;
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowCount = 2;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            panel.ControlAdded += new ControlEventHandler(OnControlAdded);
            this.Controls.Add(panel);
        }
        private void OnControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control != null)
            {
                int column = panel.GetPositionFromControl(e.Control).Column;
                int row = panel.GetPositionFromControl(e.Control).Row;
                MessageBox.Show(string.Format("Column: {0}, Row: {1}", column, row));
            }
        }
        /// <summary>
        /// Add Control to Panel
        /// </summary>
        /// <param name="column">column position</param>
        /// <param name="row">row position</param>
        private void AddControl(int column, int row)
        {
            Label label = new Label();
            label.Font = new Font(new FontFamily("Droid Sans"), 20, FontStyle.Bold);
            label.Name = "label";
            label.Text = "Whoop!";
            if (column < panel.ColumnCount && row < panel.RowCount)
                panel.Controls.Add(label, column, row);
            else
                throw new ArgumentOutOfRangeException();
        }
    }
