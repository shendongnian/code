    public partial class Form1 : Form
    {
        private String[] items; // now items available for all class members
        private int currentIndex = 0;
    
        public Form1()
        {
            InitializeComponent();
            // use using statement to close file automatically
            // ReadToEnd() returns string, so you can use it without conversion
            using(TextReader tr = new StreamReader(path_to_file))
                  items = tr.ReadToEnd().Split(',');    
        }
    
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < items.Length - 1)
            {
                textBoxLatitude.Text = items[currentIndex];
                currentIndex++
            }
        }
    }
