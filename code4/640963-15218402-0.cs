    public partial class UserControl1 : UserControl
    {
        public event EventHandler clicked;
        public UserControl1()
        {
            InitializeComponent();
            // your button
            this.button1.Click += new System.EventHandler(this.Add_Click);
        }
        public void Add_Click(object sender, EventArgs e)
        {
            if (clicked != null)
            {
               // This will fire the click event to anyone listening
                clicked(this, e);
            }
        }
    }
