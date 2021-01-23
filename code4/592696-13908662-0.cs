    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            GetPoint();
        }
        public async void GetPoint()
        {
            var point = await RetrivePointAsync();
            MessageBox.Show(point.ToString());
        }
        public Task<Point> RetrivePointAsync()
        {
            return Task.Factory.FromAsync<Point>(
                 (callback, state) => new Handler(this, callback),
                 x => ((Handler)x).Point, null);
        }
    }
