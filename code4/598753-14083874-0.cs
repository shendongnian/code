    public partial class Form1 : Form
    {
        static string CAR_IMAGE_KEY = "Car";
        static string TRUCK_IMAGE_KEY = "Truck";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetupListview();
            this.LoadListView();
        }
        private void SetupListview()
        {
            var imgList = new ImageList();
            imgList.Images.Add("Car", Properties.Resources.jpgCarImage);
            imgList.Images.Add("Truck", Properties.Resources.jpgTruckImage);
            var lv = this.listView1;
            lv.View = View.List;
            lv.SmallImageList = imgList;            
        }
        private void LoadListView()
        {
            for(int i = 1; i <= 10; i++)
            {
                string currentImageKey = CAR_IMAGE_KEY;
                if(i > 5) currentImageKey = TRUCK_IMAGE_KEY;
                var item = this.listView1.Items.Add("Item" + i.ToString(), currentImageKey);
            }
        }
