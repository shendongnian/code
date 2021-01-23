    namespace GPSCalculator
    {
        public partial class Form1 : Form
        {
            private string[] items;
            private int count = 0;
            private string fileName;
            public Form1()
            {
                InitializeComponent();
            }
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Csv Files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog(this).Equals(DialogResult.OK))
                {
                    // I've changed this to refer to the field and removed un-necessary parenthesis
                    this.fileName = ofd.FileName;
                }
            }
            private void ReadFileContents()
            {
                List<float> inputList = new List<float>(); // This doesn't get used?!
                // StreamReader is IDisposable so it should be used in a using statement
                using(TextReader tr = new StreamReader(this.fileName))
                {
                    string input = Convert.ToString(tr.ReadToEnd());
                    this.items = input.Split(',');
                }
            }
        }
    }
