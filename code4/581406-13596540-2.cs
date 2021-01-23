    public partial class Form1 : Form
    {
        private int _index;
        private List<DataPoint> _dataPoints;
        public Form1()
        {
            // Since this is a simple test application we'll do the call here
            _dataPoints = DataPoint.LoadFromFile(@"C:\Test.txt");
            InitializeComponent();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            // Cycle the data points
            _index++;
            if (_index == _dataPoints.Count)
            {
                _index = 0;
            }
            // Get the specific data point
            DataPoint dataPoint = _dataPoints[_index];
            // The empty texts are UI only, so we could check them here
            if (dataPoint.Latitude == null || dataPoint.Latitude == "")
            {
                textBoxLatitude.Text = "No Latitude Specified";
            }
            else
            {
                textBoxLatitude.Text = dataPoint.Latitude;
            }
            
            // A shorter, inline version
            textBoxLongtitude.Text = String.IsNullOrEmpty(dataPoint.Longitude) ? "No Longitude Specified" : dataPoint.Longitude;
            // Or if we don't care about empty texts
            textBoxElevation.Text = dataPoint.Elevation;
        }
    }
