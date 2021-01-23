        private Button button;
        private Dictionary<string, Image> images = new Dictionary<string, Image>();
        public Form1()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();
            AssignClickEvent();
            InitializeDictionary();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Create Buttons for all Cells in the TableLayouPanel
        /// </summary>
        private void InitializeTableLayoutPanel()
        {         
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel.RowCount; j++)
                {
                    button = new Button();
                    button.Visible = true;
                    button.Dock = DockStyle.Fill;
                    tableLayoutPanel.Controls.Add(button, i, j);
                }
            }
        }
        /// <summary>
        /// Assign a Click event of all Buttons in the TableLayoutPanel
        /// </summary>
        private void AssignClickEvent()
        {
            foreach (Control c in tableLayoutPanel.Controls.OfType<Button>())
            { 
                c.Click += new EventHandler(OnClick);
            }
        }
        /// <summary>
        /// Handle the Click event
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Click</param>
        private void OnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Visible = false;
            int column = tableLayoutPanel.GetPositionFromControl(button).Column;
            int row = tableLayoutPanel.GetPositionFromControl(button).Row;
            InitializePictureBox(column, row);
        }
        /// <summary>
        /// Create the PictureBox 
        /// </summary>
        /// <param name="column">TableLayoutPanel Column</param>
        /// <param name="row">TableLayoutPanel Row</param>
        private void InitializePictureBox(int column, int row)
        {
            PictureBox box = new PictureBox();
            box.Dock = DockStyle.Fill;
            string key = string.Format("{0}{1}", column.ToString(), row.ToString());
            box.Image = GetImageFromDictionary(key);
            tableLayoutPanel.Controls.Add(box, column, row);           
        }
        /// <summary>
        /// Get an Image from the Dictionary by Key
        /// </summary>
        /// <param name="key">the calling cell by combined column and row</param>
        /// <returns>Image</returns>
        private Image GetImageFromDictionary(string key)
        {
            return images.Where(x => x.Key == key).Select(x => x.Value).Cast<Image>().SingleOrDefault();             
        }
        /// <summary>
        /// Add Bitmaps to the Dictionary
        /// </summary>
        private void InitializeDictionary()
        {
            string key = string.Empty;
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel.RowCount; j++)
                {
                    key = string.Format("{0}", i.ToString() + j.ToString());
                    Image image = CreateBitmap();
                    images.Add(key, image);
                }
            }
        }
        /// <summary>
        /// Create Bitmaps for the Dictionary
        /// </summary>
        /// <returns>Bitmap</returns>
        private Bitmap CreateBitmap()
        {
            System.Drawing.Bitmap image = new Bitmap(button.Width, button.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    image.SetPixel(x, y, Color.Red);
                }
            }
            return image;
        }
