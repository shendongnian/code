    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
    
        private void main_Load(object sender, EventArgs e)
        {
            Control map = CreateMap();
            map.Docking = DockStyle.Fill;
            this.Controls.Add(map);
        }
    
        private Control CreateMap()
        {
           // Create a new GMaps.NET object, intialize it and return
        }
    }
