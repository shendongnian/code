    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int ROWS = 2;
        const int COLS = 2;
        Button[,] btn = new Button[ROWS,COLS];
        ComboBox[] cmb = new ComboBox[ROWS];
        private void Form1_Load(object sender, EventArgs e)
        {
            placeRows();
        }
        private readonly string[] cbTexts = new string[] { "Monday", "Tuesday" };
        public void createColumns(int rowIndex)
        {
            int s = rowIndex * 40;
            // Your original code kept overwriting btn[i] for each column.  You need a 2-D array
            // indexed by the row and column
            for (int colIndex = 0; colIndex < COLS; colIndex++)
            {
                btn[rowIndex, colIndex] = new Button();
                btn[rowIndex, colIndex].SetBounds(40 * colIndex, s, 35, 35);
                btn[rowIndex, colIndex].Text = Convert.ToString(colIndex);
                btn[rowIndex, colIndex].Tag = cbTexts[colIndex];
                panel1.Controls.Add(btn[rowIndex, colIndex]);
            }
            cmb[rowIndex] = new ComboBox();
            cmb[rowIndex].SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);
            cmb[rowIndex].Text = "Disable";
            foreach (string cbText in cbTexts)
            {
                cmb[rowIndex].Items.Add(cbText);
            }
            cmb[rowIndex].SetBounds(40, s, 70, 70);
            cmb[rowIndex].Tag = rowIndex; // Store the row index so we know which buttons to affect
            panel2.Controls.Add(cmb[rowIndex]);
        }
        void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderCmb = (ComboBox)sender;
            int row = (int)senderCmb.Tag;
            for (int col = 0; col < COLS; col++)
            {
                Button b = btn[row, col];
                // These three lines can be combined to one.  I broke it out
                // just to highlight what is happening.
                string text = ((string)b.Tag);
                bool match =  text == senderCmb.SelectedItem.ToString();
                b.Enabled = match;
            }
        }
        public void placeRows()
        {
            for (int rowIndex = 0; rowIndex < 2; rowIndex++)
            {
                createColumns(rowIndex);
            }
        }
    }
