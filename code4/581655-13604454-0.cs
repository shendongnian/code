    namespace GPSCalculator
    {
        public partial class Form1 : Form
        {
            String[] items;
            public Form1()
            {
                InitializeComponent();
                List<float> inputList = new List<float>();
                TextReader tr = new StreamReader("c:/users/tom/documents/visual studio 2010/Projects/DistanceCalculator3/DistanceCalculator3/TextFile1.txt");
                String input = Convert.ToString(tr.ReadToEnd());
                items = input.Split(',');
            }
            private void buttonNext_Click(object sender, EventArgs e)
            {
                textBoxLatitude.Text = (items[0]);
            }
        }
    }
